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
using BloonTowerMaker.Properties;
using Mono.Cecil;

namespace BloonTowerMaker
{
    public partial class PathEdit : Form
    {
        string path;
        BaseModel model;
        bool isBase = false;
        Models models;
        string lastImage = "";
        public PathEdit(string path = "000")
        {
            InitializeComponent();
            this.path = path;
            isBase = path == Resources.Base;
            models = new Models();
        }

        private void PathEdit_Load(object sender, EventArgs e)
        {
            model = models.GetBaseModel(path);

            label_path.Text = path; //get tower path from calling button
            foreach (var item in GetAllTextBoxControls(this))
            {
                try 
                { 
                    var extracted_name = item.Name.Replace("input_", "");
                    var property = model.GetType().GetField(extracted_name);
                    var value = property.GetValue(model);
                    item.Text = (string)value;
                } catch
                {
                    //Cant get property from Model
                    item.Text = "0";
                }
            }
            UpdateImages(); //Update images on form

            //Update Tower base for the 000 path
            if (!isBase)
                input_basetower.Enabled = false;
            if (models.GetBaseModel("000").basetower != null)
                input_basetower.SelectedIndex = input_basetower.Items.IndexOf(models.GetBaseModel("000").basetower);
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

            foreach (var item in GetAllTextBoxControls(this))
            {
                try
                {
                    var extracted_name = item.Name.Replace("input_", "");
                    var property = model.GetType().GetField(extracted_name);
                    property.SetValue(model,item.Text);
                }
                catch
                {
                    MessageBox.Show("Error saving value");
                }
            }

            model.tier = Models.GetPathTier(path).ToString();
            model.path = Models.GetPathRow(path);

            //if (isBase)
            //    models.UpdateBaseModel(model);
            //else
            models.UpdateBaseModel(model, path);

            MainForm.ActiveForm.Update();
        }


        private void RemoveImage(object sender, string path)
        {
            var img = sender as PictureBox;
            try
            {
                img.Image?.Dispose();
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

        private IEnumerable<Control> GetAllTextBoxControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllTextBoxControls(c));
                if (c is TextBox)
                    controlList.Add(c);
            }
            return controlList;
        }

        private void input_basetower_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (input_basetower.SelectedIndex)
            {
                case 0: model.basetower = "TowerType.DartMonkey"; break;
                default:
                        model.basetower = "TowerType.DartMonkey"; break;

            }
            models.UpdateBaseModel(model,path);
        }
    }
}
