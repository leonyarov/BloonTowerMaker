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
using BloonTowerMaker.Data;
using BloonTowerMaker.Logic;
using BloonTowerMaker.Properties;

namespace BloonTowerMaker
{
    public partial class MainForm : Form
    {
        BaseModel data;
        Models models;
        private Project towerProject;

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
            var name = b.Name.Replace("btn_t", "");
            Edit(name);
        }
        private void PathHover(object sender, EventArgs e)
        {
            var b = sender as Button;
            var name = b.Name.Replace("btn_t", "");
            var model = models.GetBaseModel(name);
            label_cost.Text = model.cost;
            label_description.Text = model.description;
            img_base.Image?.Dispose();
            img_base.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, name);
        }
        private void img_base_Click(object sender, EventArgs e)
        {
            Edit("000");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            towerProject = Project.Load();
            currdir.Text = towerProject.projectPath;
            data = models.GetBaseModel(Resources.Base);
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains("btn_t")) continue;
                item.Click += PathSelect;
                item.MouseEnter += PathHover;
                item.MouseLeave += MouseLeaveIcon;
                item.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.ICON, item.Name.Replace("btn_t", ""));
                item.BackgroundImageLayout = ImageLayout.Stretch;
                item.TextAlign = ContentAlignment.BottomCenter;
            }

            input_type.SelectedIndex = data.set != null
                ? input_type.Items.IndexOf(data.set) +1
                : 0;

            int[] path = new int[3];
            if (int.TryParse(data.top, out path[0]))
                input_top.Value = path[0];
            if (int.TryParse(data.middle, out path[1]))
                input_middle.Value = path[1];
            if (int.TryParse(data.buttom, out path[2]))
                input_buttom.Value = path[2];
            disablePathButton(path);
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
        }

        private void MouseLeaveIcon(object sender, EventArgs e)
        {
            label_cost.Text = data.cost;
            label_description.Text = data.description;
            img_base.Image?.Dispose();
            img_base.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, "000");
        }
        private void MainForm_Enter(object sender, EventArgs e)
        {
            MouseLeaveIcon(sender,e);
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (!item.Name.Contains("btn_t")) continue;
                var path = item.Name.Replace("btn_t", "");
                item.BackgroundImage?.Dispose();
                item.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.ICON,path);
                item.Text = models.GetBaseModel(path).name;
            }
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            var box = sender as ComboBox;
            switch (box.SelectedIndex)
            {
                case 0: this.BackgroundImage = Properties.Resources.primary;
                    data.set = "PRIMARY";
                    break;
                case 1: this.BackgroundImage = Properties.Resources.army;
                    data.set = "MILITARY";
                    break;
                case 2: this.BackgroundImage = Properties.Resources.magic; 
                    data.set = "MAGIC";
                    break;
                case 3: this.BackgroundImage = Properties.Resources.support; 
                    data.set = "SUPPORT";
                    break;
                default:
                    this.BackgroundImage = Properties.Resources.primary;
                    data.set = "PRIMARY";
                    break;
            }
            models.UpdateBaseModel(data,"000");
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
            data.top = input_top.Value.ToString();
            disablePathButton( new[] {(int)input_top.Value , (int)input_middle.Value, (int)input_buttom.Value});
            models.UpdateBaseModel(data, Resources.Base);
        }

        private void input_middle_ValueChanged(object sender, EventArgs e)
        {
            data.middle = input_middle.Value.ToString();
            disablePathButton(new[] { (int)input_top.Value, (int)input_middle.Value, (int)input_buttom.Value });
            models.UpdateBaseModel(data, Resources.Base);
        }

        private void input_buttom_ValueChanged(object sender, EventArgs e)
        {
            data.buttom = input_buttom.Value.ToString();
            disablePathButton(new[] { (int)input_top.Value, (int)input_middle.Value, (int)input_buttom.Value });
            models.UpdateBaseModel(data, Resources.Base);
        }

        private void disablePathButton(int[] max)
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
                    case "TOP":    allowed = max[0]; break;
                    case "MIDDLE": allowed = max[1]; break;
                    case "BOTTOM": allowed = max[2]; break;
                }
                item.Enabled = allowed >= tier;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Project.Save(towerProject);
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
    }
}
