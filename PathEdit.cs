using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloonTowerMaker.Data;
using BloonTowerMaker.Logic;

namespace BloonTowerMaker
{
    public partial class PathEdit : Form
    {
        string path;
        BaseModel baseModel;
        TemplateModel templateModel;
        bool isBase = false;
        Models models;
        string lastImage = "";
        public PathEdit(string path = "000")
        {
            InitializeComponent();
            this.path = path;
            isBase = path == "000";
            models = new Models();
        }

        private void PathEdit_Load(object sender, EventArgs e)
        {
            label_path.Text = path; //get tower path from calling button
            if (isBase)
            {
                baseModel = models.GetBaseModel();
                input_cost.Text = baseModel.cost;
                input_desc.Text = baseModel.description;
                input_name.Text = baseModel.name;

            }
            else
            {
                templateModel = models.GetTemplateModel(path);
                input_cost.Text = templateModel.cost;
                input_desc.Text = templateModel.description;
                input_name.Text = templateModel.name;
            }
            UpdateImages(); //Update images on form
        }

        private void UpdateImages()
        {

            img_display.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, path);
            img_icon.Image = SelectImage.GetImage(SelectImage.image_type.ICON, path);
            img_projectile.Image = SelectImage.GetImage(SelectImage.image_type.PROJECTILE, path);
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PathEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isBase)
            {
                baseModel.cost = input_cost.Text;
                baseModel.description = input_desc.Text;
                baseModel.name = input_name.Text;

            }
            else
            {
                templateModel.cost = input_cost.Text;
                templateModel.description = input_desc.Text;
                templateModel.name = input_name.Text;
            }
            if (isBase)
                models.UpdateBaseModel(baseModel);
            else
                models.UpdateTemplateModel(templateModel, path);
            MainForm.ActiveForm.Update();
        }


        private void RemoveImage(object sender, string path)
        {
            var img = sender as PictureBox;
            try
            {
                if (img.Image != null)
                    img.Image.Dispose();
                File.Delete(Models.getImagesPath(path) + $"{lastImage}.png");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Cant delete Image");
            }
            UpdateImages();
        }

        private void image_select_dialog_FileOk(object sender, CancelEventArgs e)
        {
            var file = image_select_dialog.FileName;
            try
            {
                File.Copy(file, Models.getImagesPath(path) + $"{lastImage}.png", true);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error getting image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateImages(); //Update images on form

        }

        private void PathEdit_Enter(object sender, EventArgs e)
        {
            PathEdit_Load(sender, e);
        }

        private void img_display_MouseClick(object sender, MouseEventArgs e)
        {
            lastImage = "portrait";
            if (e.Button == MouseButtons.Right)
            {
                RemoveImage(sender, path);
                return;
            }
            image_select_dialog.ShowDialog();
        }

        private void img_projectile_MouseClick(object sender, MouseEventArgs e)
        {
            lastImage = "projectile";
            if (e.Button == MouseButtons.Right)
            {
                RemoveImage(sender, path);
                return;
            }
            image_select_dialog.ShowDialog();
        }

        private void img_icon_MouseClick(object sender, MouseEventArgs e)
        {
            lastImage = "icon";
            if (e.Button == MouseButtons.Right)
            {
                RemoveImage(sender, path);
                return;
            }
            image_select_dialog.ShowDialog();
        }
    }
}
