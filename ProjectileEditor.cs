using BloonTowerMaker.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BloonTowerMaker.Properties;
using System.IO;
using Assets.Scripts.Models.Towers.Weapons;
using Mono.Cecil;

namespace BloonTowerMaker
{
    public partial class ProjectileEditor : Form
    {
        //private Projectile selectedProjectile;
        private ModelToList<WeaponModel> selectedProjectile;
        private string lastImagePath;
        /// <summary>
        /// key - projectile name, value - projectile image path
        /// </summary>
        public ProjectileEditor()
        {
            InitializeComponent();
        }
        void RefreshList()
        {
            try
            {
                listProjectiles.Items.Clear();
                //listProjectiles.Items.AddRange(Projectile.getProjectileNames().ToArray());
                var pathToFiles = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder);
                var files = Directory.GetFiles(pathToFiles);
                var fileNames = new List<string>(files).Where(x => x.Contains(".json"))
                    .Select(Path.GetFileNameWithoutExtension);
                listProjectiles.Items.AddRange(fileNames.ToArray());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
        private void ProjectileEditor_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void ProjectileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            //TODO: at projectile window close
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            var newFileName = "NewProjectile";
            if (listProjectiles.Items.Contains(newFileName))
            {
                MessageBox.Show("Rename the previews 'NewProjectile'");
                return;
            }
            try
            {
                //selectedProjectile = new Projectile();
                
            }
            catch (Exception err)
            {
                MessageBox.Show("Error creating projectile", err.Message);
            }

            //selectedProjectile = new ModelToList<WeaponModel>(Path.Combine(Project.instance.projectPath,Resources.ProjectileFolder,newFileName + ".json"));
            listProjectiles.Items.Add("NewProjectile");
            listProjectiles.SelectedItem = listProjectiles.Items[listProjectiles.Items.Count - 1];
            selectedProjectile.Edit("name", newFileName);

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (listProjectiles.SelectedItems.Count != 1) return;
            var name = listProjectiles.SelectedItems[0].ToString();
            var index = listProjectiles.SelectedIndex;
            listProjectiles.Items.RemoveAt(index);
            img_projectile.Image?.Dispose();
            //Projectile.Delete(name);
            selectedProjectile.Delete();
        }

        private void img_projectile_Click(object sender, EventArgs e)
        {
            if (listProjectiles.SelectedItems.Count == 0) return;
            selectImageDialog.ShowDialog();
        }

        private void selectImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var projectileName = listProjectiles.SelectedItems[0].ToString().Replace(" ","") + ".png";
            lastImagePath = selectImageDialog.FileName;
            img_projectile.Image?.Dispose();
            img_projectile.Image = Image.FromFile(lastImagePath);
            File.Copy(lastImagePath,Path.Combine(Project.instance.projectPath,Resources.ProjectileFolder, projectileName),true);
        }

        private void dataGridProjectile_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var name = dataGridProjectile.Rows[e.RowIndex].Cells[1].Value.ToString();
            var value = dataGridProjectile.Rows[e.RowIndex].Cells[2].Value.ToString();
            //var name = selectedProjectile.FindValue("name");
            if (listProjectiles.Items.Contains(name))
            {
                MessageBox.Show("Cannot set projectile name that already exist");
                return;
            }
            //var valueDict = selectedProjectile.GetValues();
            selectedProjectile.data.UpdateFromDataTable(this.dataGridProjectile.DataSource as DataTable);
            selectedProjectile.Save();
            if (name == "name")
            {
                img_projectile.Image?.Dispose();
                selectedProjectile.Rename(value);
                RefreshList();
            }
            //valueDict.UpdateFromDataTable(this.dataGridProjectile.DataSource as DataTable);
            //selectedProjectile.SetValues(valueDict);
            //if (name == "name")
                //btn_delete_Click(sender,e);
                //Projectile.Delete(selectedProjectile.GetValues()["name"]);
            //selectedProjectile.Save();
            //if (name == "name")
                //RefreshList();
            //    listProjectiles.Items[listProjectiles.Items.IndexOf(listProjectiles.SelectedItems[0])] = dataGridProjectile.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void listProjectiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProjectiles.SelectedItems.Count == decimal.Zero) return;
            //selectedProjectile = new Projectile(listProjectiles.SelectedItems[0].ToString(), true);
            var newPath = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder,
                listProjectiles.SelectedItems[0].ToString() + ".json");
            selectedProjectile = new ModelToList<WeaponModel>(newPath);
            //dataGridProjectile.DataSource = selectedProjectile.ToDataTable<string>();
            dataGridProjectile.DataSource = selectedProjectile.data.ToDataTable();
            //var imagePath = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder,selectedProjectile.GetValues()["name"] + ".png");
            var imagePath = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder,selectedProjectile.FindValue("name")+ ".png");
            img_projectile.Image?.Dispose();
            if (File.Exists(imagePath))
                img_projectile.Image = Image.FromFile(imagePath);
            else
                img_projectile.Image = null;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Renaming a projectile will require you to assign a new image to it or it wont compile properly","Be aware!");
        }
    }
}
