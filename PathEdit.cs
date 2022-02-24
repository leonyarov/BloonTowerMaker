using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using BloonTowerMaker.Data;
using BloonTowerMaker.Logic;
using BloonTowerMaker.Properties;

namespace BloonTowerMaker
{
    public partial class PathEdit : Form
    {
        string path;
        Dictionary<string, string> model;
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
            var dict = Models.ExtractProperties<TowerModel>(); 
            model = models.GetTowerModel(path); //get model path
            foreach (var key in dict.Keys.ToArray())
            {
                var item = new ListViewItem(key);
                item.Name = key;
                item.SubItems.Add(model[key]);
                item.SubItems.Add(dict[key]);
                propertiesList.Items.Add(item);
            }
            this.Text = $"Path: {path}"; //get tower path from calling button
           
            UpdateImages(); //Update images on form

        }

        private void UpdateImages()
        {
            img_icon.Image?.Dispose();
            img_display.Image?.Dispose();
            img_display.Image = SelectImage.GetImage(SelectImage.image_type.PORTRAIT, path);
            img_icon.Image = SelectImage.GetImage(SelectImage.image_type.ICON, path);
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PathEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

            foreach (ListViewItem key in propertiesList.Items)
            {
                var value = key.SubItems[1].Text;
                model[key.Text] = value;
            }

            model["tier"]= Models.GetPathTier(path).ToString();
            model["path"] = Models.GetPathRow(path);

            models.UpdateBaseModel(model, path);

            MainForm.ActiveForm.Update();
        }


        private void RemoveImage(string path)
        {
            var imagename = propertiesList.Items["name"].SubItems[1].Text;
            if (string.IsNullOrWhiteSpace(imagename))
            {
                MessageBox.Show("Path name cannot be empty to remove an image");
                return;
            }
            try
            {
                File.Delete(Path.Combine(Project.instance.projectPath,Models.ParsePath(path),$"{imagename}{lastImage}.png"));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Cant delete Image");
            }
            UpdateImages();
        }

        private void image_select_dialog_FileOk(object sender, CancelEventArgs e)
        {
            var imagename = propertiesList.Items["name"].SubItems[1].Text;
            if (string.IsNullOrWhiteSpace(imagename))
            {
                MessageBox.Show("Path name cannot be empty to set an image");
                return;
            }
            var file = image_select_dialog.FileName;
            try
            {
                var new_filename = Path.Combine(Project.instance.projectPath, Models.ParsePath(path),
                    $"{imagename}{lastImage}.png");
                File.Copy(file,new_filename , true);
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
            lastImage = "-Portrait";
            if (e.Button == MouseButtons.Right)
            {
                img_display.Image?.Dispose();
                img_display.Image = null;
                RemoveImage(path);
                return;
            }
            image_select_dialog.ShowDialog();
        }
        private void img_icon_MouseClick(object sender, MouseEventArgs e)
        {
            lastImage = "-Icon";
            if (e.Button == MouseButtons.Right)
            {
                img_icon.Image?.Dispose();
                img_display.Image = null;
                RemoveImage(path);
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

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (propertiesList.SelectedItems.Count != 1) return;
            propertiesList.SelectedItems[0].SubItems[1].Text = input_property.Text;
        }
    }
}
