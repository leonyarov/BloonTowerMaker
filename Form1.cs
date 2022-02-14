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
        public MainForm()
        {
            InitializeComponent();
            models = new Models();
            combo_type.SelectedIndex = 0;
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
            //img_base.Image = model.display;
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
                }
            }

        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            data = models.GetBaseModel();
            label_cost.Text = data.cost;
            label_description.Text = data.description;
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox box = sender as ComboBox;
            switch (box.SelectedIndex)
            {
                case 0: this.BackgroundImage = (Image)Properties.Resources.primary;  break;
                case 1: this.BackgroundImage = (Image)Properties.Resources.army; break;
                case 2: this.BackgroundImage = Properties.Resources.magic; break;
                case 3: this.BackgroundImage = Properties.Resources.support; break;
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
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),"Failed to compile",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            MessageBox.Show("Tower Created");
        }
    }
}
