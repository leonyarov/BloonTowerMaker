using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
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

            int path = 0;
            if (int.TryParse(data.top, out path))
                input_top.Value = path;
            disablePathButton(0,path);
            if (int.TryParse(data.middle, out path))
                input_middle.Value = path;
            disablePathButton(1,path);
            if (int.TryParse(data.buttom, out path))
                input_buttom.Value = path;
            disablePathButton(2,path);
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
            models.UpdateBaseModel(data,"000");
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
            disablePathButton(0,(int)input_top.Value);
        }

        private void input_middle_ValueChanged(object sender, EventArgs e)
        {
            data.middle = input_middle.Value.ToString();
            disablePathButton(1,(int)input_middle.Value);
        }

        private void input_buttom_ValueChanged(object sender, EventArgs e)
        {
            data.buttom = input_buttom.Value.ToString();
            disablePathButton(2,(int)input_buttom.Value);
        }

        private void disablePathButton(int index,int max)
        {
            foreach (var item in this.Controls.OfType<Button>())
            {
                var is_btn = item.Name.Contains("btn_t");
                var i = -1;
                int.TryParse(item.Name.Replace("btn_t", "").Substring(index,1),out i);
                if (is_btn && i > max)
                    item.Enabled = false;
                else if (is_btn && (int) i <= max)
                    item.Enabled = true;
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
