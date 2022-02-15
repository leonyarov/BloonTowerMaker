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

namespace BloonTowerMaker
{
    public partial class MainForm : Form
    {
        BaseModel data;
        Models models;

        public object ImageSelect { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            models = new Models();
        }


        private void Edit(string path)
        {
            PathEdit edit = new PathEdit(path);
            edit.ShowDialog();
            edit.Focus();
        }
        private void PathSelect(object sender, EventArgs e)
        {
            Button b = sender as Button;
            var name = b.Name.Replace("btn_t", "");
            Edit(name);
        }
        private void PathHover(object sender, EventArgs e)
        {
            Button b = sender as Button;
            var name = b.Name.Replace("btn_t", "");
            var model = models.GetTemplateModel(name);
            label_cost.Text = model.cost;
            label_description.Text = model.description;
            img_base.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, name);
        }
        private void img_base_Click(object sender, EventArgs e)
        {
            Edit("000");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls.OfType<Button>())
            {
                if (item.Name.Contains("btn_t"))
                {
                    item.Click += PathSelect;
                    item.MouseEnter += PathHover;
                    item.MouseLeave += MainForm_Enter;
                    item.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.ICON, item.Name.Replace("btn_t", ""));
                    item.BackgroundImageLayout = ImageLayout.Stretch;
                    item.Text = "";
                }
            }

        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            data = models.GetBaseModel();
            label_cost.Text = data.cost;
            label_description.Text = data.description;
            img_base.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, "000");

            foreach (var item in this.Controls.OfType<Button>())
            {
                if (item.Name.Contains("btn_t"))
                {
                    if (item.BackgroundImage != null)
                        item.BackgroundImage.Dispose();
                    item.BackgroundImage = SelectImage.GetImage(SelectImage.image_type.ICON, item.Name.Replace("btn_t", ""));
                }
            }

        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox box = sender as ComboBox;
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
                    break;
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            Compile cmp = new Compile();
            try
            {
                cmp.CompileTower();
                MessageBox.Show("Tower Created");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),"Failed to compile",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
