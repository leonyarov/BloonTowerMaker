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
using Mono.Cecil;

namespace BloonTowerMaker
{
    public partial class MainForm : Form
    {
        //Dictionary<string,string> data;
        Models models;
        private Project towerProject;
        ModelToList<TowerModel> data;
        public object ImageSelect { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            models = new Models();
        }


        private void Edit(string path)
        {
            var edit = new PathEdit(path);
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
            var b = sender as Button;
            var path = b.Name.Replace(Resources.PathButtonIndentifier, "");
            var pathToFile = Models.GetJsonPath(path);
            var model = new ModelToList<TowerModel>(pathToFile);
                //models.GetTowerModel(name);
            //label_cost.Text = model["cost"];
            label_cost.Text = model.FindValue("cost");
            label_description.Text = model.FindValue("description");
            //label_description.Text = model["description"];
            img_base.Image?.Dispose();
            img_base.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, path);
            //tower_name.Text = model["name"];
            tower_name.Text = model.FindValue("name");
        }
        private void img_base_Click(object sender, EventArgs e)
        {
            img_base.Image?.Dispose();
            img_base.Image = null;
            Edit("000");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            towerProject = Project.Load();
            currdir.Text = towerProject.projectPath;
            //data = models.GetTowerModel(Resources.Base);
            data = new ModelToList<TowerModel>(Models.GetJsonPath(Resources.Base));
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains(Resources.PathButtonIndentifier)) continue;
                item.Click += PathSelect;
                item.MouseEnter += PathHover;
                item.MouseLeave += MouseLeaveIcon;
                item.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.ICON, item.Name.Replace(Resources.PathButtonIndentifier, ""));
                item.BackgroundImageLayout = ImageLayout.Stretch;
                item.TextAlign = ContentAlignment.BottomCenter;
            }

            //input_type.SelectedIndex = data["towerSet"] != null
            //    ? input_type.Items.IndexOf(data["towerSet"]) + 1
            //    : 0;
            input_type.SelectedIndex = data.FindValue("towerSet") != null
                ? input_type.Items.IndexOf(data.FindValue("towerSet")) + 1
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

            combo_base.SelectedItem = data.FindValue("baseTower");
            //combo_base.SelectedItem = data["baseTower"];
        }

        private void MouseLeaveIcon(object sender, EventArgs e)
        {
            label_cost.Text = data.FindValue("cost");
            //label_cost.Text = data["cost"];
            label_description.Text = data.FindValue("description");
            //label_description.Text = data["description"];
            img_base.Image?.Dispose();
            img_base.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, Resources.Base);
            tower_name.Text = data.FindValue("name");
            //tower_name.Text = data["name"];

        }
        private void MainForm_Enter(object sender, EventArgs e)
        {
            MouseLeaveIcon(sender,e);
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains("btn_t")) continue;
                var path = item.Name.Replace("btn_t", "");
                var tempModel = new ModelToList<TowerModel>(Models.GetJsonPath(path));
                item.BackgroundImage?.Dispose();
                item.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.ICON,path);
                //item.Text = models.GetTowerModel(path)["name"];
                item.Text = tempModel.FindValue("name");
            }
            //data = models.GetTowerModel(Resources.Base);
            data = new ModelToList<TowerModel>(Models.GetJsonPath(Resources.Base));
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            data = new ModelToList<TowerModel>(Models.GetJsonPath(Resources.Base));
            var box = sender as ComboBox;
            switch (box.SelectedIndex)
            {
                case 0: this.BackgroundImage = Properties.Resources.primary;
                    //data["towerSet"] = "PRIMARY";
                    data.Edit("name", "PRIMARY");
                    break;
                case 1: this.BackgroundImage = Properties.Resources.army;
                    data.Edit("name", "MILITARY");
                    //data["towerSet"] = "MILITARY";
                    break;
                case 2: this.BackgroundImage = Properties.Resources.magic;
                    data.Edit("name", "MAGIC");
                    //data["towerSet"] = "MAGIC";
                    break;
                case 3: this.BackgroundImage = Properties.Resources.support;
                    data.Edit("name", "SUPPORT");
                    //data["towerSet"] = "SUPPORT";
                    break;
                default:
                    this.BackgroundImage = Properties.Resources.primary;
                    data.Edit("name", "PRIMARY");
                    //data["towerSet"] = "PRIMARY";
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
            Project.instance.TopPathUpgrade = (int)input_top.Value;
            disablePathButton();
            Project.Save();
        }

        private void input_middle_ValueChanged(object sender, EventArgs e)
        {
            Project.instance.MiddlePathUpgrades = (int)input_top.Value;
            disablePathButton();
            Project.Save();
        }

        private void input_buttom_ValueChanged(object sender, EventArgs e)
        {
            Project.instance.BottomPathUpgrades = (int)input_top.Value;
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
            data = new ModelToList<TowerModel>(Models.GetJsonPath(Resources.Base));
            //data["baseTower"] = combo_base.SelectedItem.ToString();
            data.Edit("baseTower",combo_base.SelectedItem.ToString());
            //models.UpdateBaseModel(data, Resources.Base);
        }
    }
}
