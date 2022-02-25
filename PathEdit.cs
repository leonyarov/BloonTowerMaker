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
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Simulation.Towers;
using BloonTowerMaker.Data;
using BloonTowerMaker.Logic;
using BloonTowerMaker.Properties;

namespace BloonTowerMaker
{
    public partial class PathEdit : Form
    {
        string path;
        bool isBase = false;
        string lastImage = "";

        private ModelToList<TowerModel> pathModel;
        private ModelToList<AttackModel> attackModel;
        private Dictionary<string, List<string>> selectedProjectiles = new Dictionary<string, List<string>>();
        public PathEdit(string path = "000")
        {
            InitializeComponent();
            this.path = path;
            isBase = path == Resources.Base;
        }

        private void PathEdit_Load(object sender, EventArgs e)
        {
            pathModel = new ModelToList<TowerModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerPathJsonFile));
            dataGridPathProperty.DataSource = pathModel.data.ToDataTable();

            attackModel = new ModelToList<AttackModel>(Path.Combine(Project.instance.projectPath,Models.ParsePath(path),Resources.TowerAttackJsonFile));
            dataGridPathAttack.DataSource = attackModel.data.ToDataTable();


            List<string> projectileNames = new List<string>();
            foreach (var file in Directory.GetFiles(Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder),"*.json"))
            {
                ModelToList<WeaponModel> weapon = new ModelToList<WeaponModel>(file);
                projectileNames.Add(weapon.FindValue("name"));
            }

            dataGridProjectiles.DataSource = projectileNames.ToDataTableWithCheckbox();
            this.Text = $"Path: {path}"; //get tower path from calling button
            UpdateImages(); //Update images on form


            //Load selected projectiles
            selectedProjectiles= selectedProjectiles.loadSelected();
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
            pathModel.data.UpdateFromDataTable(dataGridPathProperty.DataSource as DataTable);
            pathModel.Edit("tier", Models.GetPathTier(path).ToString());
            pathModel.Edit("path", Models.GetPathRow(path));
            pathModel.Save();
            MainForm.ActiveForm.Update();
        }


        private void RemoveImage(string path)
        {
            var imageName = pathModel.Find("name")[2];
            if (string.IsNullOrWhiteSpace(imageName))
            {
                MessageBox.Show("Path name cannot be empty to remove an image");
                return;
            }
            try
            {
                File.Delete(Path.Combine(Project.instance.projectPath,Models.ParsePath(path),$"{imageName}{lastImage}.png"));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Cant delete Image, Try to re-open the path");
            }
            UpdateImages();
        }

        private void image_select_dialog_FileOk(object sender, CancelEventArgs e)
        {
            var imageName = pathModel.Find("name")[2];
            if (string.IsNullOrWhiteSpace(imageName))
            {
                MessageBox.Show("Path name cannot be empty to set an image");
                return;
            }
            var file = image_select_dialog.FileName;
            try
            {
                var new_filename = Path.Combine(Project.instance.projectPath, Models.ParsePath(path),
                    $"{imageName}{lastImage}.png");
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

        //Image Select
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


        private void dataGridPathProperty_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            pathModel.data.UpdateFromDataTable(dataGridPathProperty.DataSource as DataTable);
            pathModel.Save();
        }

        private void dataGridPathAttack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            attackModel.data.UpdateFromDataTable(dataGridPathAttack.DataSource as DataTable);
            attackModel.Save();
        }

        private void dataGridProjectiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridProjectiles[e.ColumnIndex,e.RowIndex].Value as bool?; //get checkbox value
            if (value == null || value.GetType() != typeof(bool)) return;
            var name = dataGridProjectiles[e.ColumnIndex-1, e.RowIndex].Value.ToString(); //get checkbox name
            if ((bool)value)
                selectedProjectiles[name].Add(path);
            else
                selectedProjectiles[name].Remove(pathModel.FindValue(path));
            selectedProjectiles.saveSelected();

        }
    }
}
