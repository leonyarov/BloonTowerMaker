using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Assets.Scripts.Models.ServerEvents;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Track;
using BloonTowerMaker.Data;
using BloonTowerMaker.Logic;
using BloonTowerMaker.Properties;
using BTD_Mod_Helper.Api.Towers;
using Mono.Cecil;

namespace BloonTowerMaker
{
    public partial class MainForm : Form
    {
        //Dictionary<string,string> data;
        Models models;
        private Project towerProject;
        private ModelToList<ModTower> baseTower;
        private ModelToList<ModUpgrade> upgradeTower;
        public static bool debugTextures;

        public object ImageSelect { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            models = new Models();
            debugTextures = false;
        }


        private void Edit(string path)
        {
            var edit = new PathEdit(path);
            img_base.Image?.Dispose();
            edit.ShowDialog();
            edit.Focus();
        }
        private void PathSelect(object sender, EventArgs e)
        {
            var b = sender as Button;
            var name = b.Name.Replace(Resources.PathButtonIndentifier, "");
            Edit(name);
        }
        private void PathHover(object sender, EventArgs e)
        {
            //Get model path from button
            var b = sender as Button;
            var path = b.Name.Replace(Resources.PathButtonIndentifier, "");
            var pathToFile = Models.GetJsonPath(path);

            //Get temp model
            var model = new ModelToList<ModUpgrade>(pathToFile);

            //Set label values 
            label_cost.Text = model.FindValue("Cost");
            label_description.Text = model.FindValue("Description");
            tower_name.Text = model.FindValue("DisplayName");

            //Load Images
            img_base.Image?.Dispose();
            img_base.Image = SelectImage.LoadImage(model.FindValue("Portrait"));
        }
        private void img_base_Click(object sender, EventArgs e)
        {
            img_base.Image?.Dispose();
            Edit("000");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            towerProject = Project.Load();
            currdir.Text = towerProject.projectPath;

            //Load base file from folder
            baseTower = new ModelToList<ModTower>(Models.GetJsonPath(Resources.Base));

            //Load Up each button
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains(Resources.PathButtonIndentifier)) continue;
                var path = item.Name.Replace(Resources.PathButtonIndentifier, "");
                var model = new ModelToList<ModUpgrade>(Models.GetJsonPath(path));
                item.Click += PathSelect;
                item.MouseEnter += PathHover;
                item.MouseLeave += MouseLeaveIcon;
                item.BackgroundImage = SelectImage.LoadImage(model.FindValue("Icon"));
                item.BackgroundImageLayout = ImageLayout.Stretch;
                item.TextAlign = ContentAlignment.BottomCenter;
            }

            input_type.SelectedIndex = baseTower.FindValue("TowerSet") != null
                ? input_type.Items.IndexOf(baseTower.FindValue("TowerSet")) + 1
                : 0;

            input_top.Value = Project.instance.TopPathUpgrade;
            input_middle.Value = Project.instance.MiddlePathUpgrades;
            input_buttom.Value = Project.instance.BottomPathUpgrades;

            disablePathButton();
            recentToolStripMenuItem.DropDown = new ToolStripDropDown();
            foreach (var defaultRecentPath in Settings.Default.RecentPaths ?? new StringCollection())
            {
                if (defaultRecentPath == "none") continue;
                var dropdown = new ToolStripMenuItem(defaultRecentPath);
                dropdown.Click += (o, args) =>
                {
                    Project.LoadFromRecent(Settings.Default.RecentPaths.IndexOf(defaultRecentPath));
                    Application.Restart();
                };
                recentToolStripMenuItem.DropDownItems.Add(dropdown);
            }

            var monkeyTypes = typeof(TowerType).GetProperties();
            foreach (var propertyInfo in monkeyTypes)
            {
                if (propertyInfo.PropertyType.Name != nameof(String)) continue;
                combo_base.Items.Add(propertyInfo.Name);
            }

            //Find the baseTower reference in the 000 path
            combo_base.SelectedItem = baseTower.FindValue("BaseTower");
        }

        private void MouseLeaveIcon(object sender, EventArgs e)
        {
            //--- Get Base tower data to show when cursor is not over anythingf
            label_cost.Text = baseTower.FindValue("Cost");
            label_description.Text = baseTower.FindValue("Description");
            img_base.Image?.Dispose();
            img_base.Image = SelectImage.LoadImage(baseTower.FindValue("Portrait"));
            //img_base.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, Resources.Base);
            tower_name.Text = baseTower.FindValue("DisplayName");
        }
        private void MainForm_Enter(object sender, EventArgs e)
        {
            MouseLeaveIcon(sender,e);
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains("btn_t")) continue;
                var path = item.Name.Replace("btn_t", "");
                var tempModel = new ModelToList<ModUpgrade>(Models.GetJsonPath(path));
                item.BackgroundImage?.Dispose();
                item.BackgroundImage = SelectImage.LoadImage(tempModel.FindValue("Icon"));
                item.Text = tempModel.FindValue("DisplayName");
            }

            //Refresh base data from json file (after path window was closed)
            baseTower = new ModelToList<ModTower>(Models.GetJsonPath(Resources.Base));

        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = sender as ComboBox;
            switch (box.SelectedIndex)
            {
                case 0: this.BackgroundImage = Properties.Resources.primary;
                    //data.Edit("TowerSet", "PRIMARY");
                    baseTower.Edit("TowerSet", "PRIMARY");
                    break;
                case 1: this.BackgroundImage = Properties.Resources.army;
                    //data.Edit("TowerSet", "MILITARY");
                    baseTower.Edit("TowerSet", "MILITARY");
                    break;
                case 2: this.BackgroundImage = Properties.Resources.magic;
                    //data.Edit("TowerSet", "MAGIC");
                    baseTower.Edit("TowerSet", "MAGIC");
                    break;
                case 3: this.BackgroundImage = Properties.Resources.support;
                    //data.Edit("TowerSet", "SUPPORT");
                    baseTower.Edit("TowerSet", "SUPPORT");
                    break;
                default:
                    this.BackgroundImage = Properties.Resources.primary;
                    baseTower.Edit("TowerSet", "PRIMARY");
                    //data.Edit("TowerSet", "PRIMARY");
                    break;
            }
            //models.UpdateBaseModel(data,"000");
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            var cmp = new Compile();
            try
            {
                cmp.CompileTower(towerProject);
                MessageBox.Show("Tower Created");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),"Failed to compile",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void input_top_ValueChanged(object sender, EventArgs e)
        {
            var value = (int) input_top.Value;
            Project.instance.TopPathUpgrade = value;
            baseTower.Edit("TopPathUpgrades", value.ToString());
            disablePathButton();
            Project.Save();
        }

        private void input_middle_ValueChanged(object sender, EventArgs e)
        {
            var value = (int)input_middle.Value;
            Project.instance.MiddlePathUpgrades = value;
            baseTower.Edit("MiddlePathUpgrades", value.ToString());
            disablePathButton();
            Project.Save();
        }

        private void input_buttom_ValueChanged(object sender, EventArgs e)
        {
            var value = (int)input_buttom.Value;
            Project.instance.BottomPathUpgrades = value;
            baseTower.Edit("BottomPathUpgrades", value.ToString());
            disablePathButton();
            Project.Save();
        }

        private void disablePathButton()
        {
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains("btn_t")) continue;
                var path = item.Name.Replace("btn_t", "");
                var row = Models.GetPathRow(path);
                var tier = Models.GetPathTier(path);
                var allowed = 0;
                switch (row)
                {
                    case "TOP":    allowed = Project.instance.TopPathUpgrade; break;
                    case "MIDDLE": allowed = Project.instance.MiddlePathUpgrades; break;
                    case "BOTTOM": allowed = Project.instance.BottomPathUpgrades; break;
                }
                item.Enabled = allowed >= tier;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Project.Save();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = Project.GetFolder();
            towerProject = Project.New(true);
            Application.Restart();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.GetFolder();
            Application.Restart();
        }

        private void btn_projectile_editor_Click(object sender, EventArgs e)
        {
            ProjectileEditor editor = new ProjectileEditor();
            editor.ShowDialog();
        }

        private void combo_base_SelectedIndexChanged(object sender, EventArgs e)
        {
            //data = new ModelToList<TowerModel>(Models.GetJsonPath(Resources.Base));
            //data["baseTower"] = combo_base.SelectedItem.ToString();
            //data.Edit("baseTower",combo_base.SelectedItem.ToString());
            baseTower.Edit("BaseTower",combo_base.SelectedItem.ToString());
            //models.UpdateBaseModel(data, Resources.Base);
        }

        private void checkBox_DebugTextures_CheckStateChanged(object sender, EventArgs e)
        {
            debugTextures = checkBox_DebugTextures.Checked;
        }
    }
}
