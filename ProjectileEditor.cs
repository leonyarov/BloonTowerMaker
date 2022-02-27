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
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;

namespace BloonTowerMaker
{
    public partial class ProjectileEditor : Form
    {
        //private Projectile selectedProjectile;
        private ModelToList<DamageModel> selectedDamage;
        private ModelToList<ProjectileModel> selectedProjectile;
        private Dictionary<string, List<string>> projectileDictionary = new Dictionary<string, List<string>>();

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
            projectileDictionary = projectileDictionary.loadSelected();
        }

        private void ProjectileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            
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

            //selectedProjectile = new ModelToList<DamageModel>(Path.Combine(Project.instance.projectPath,Resources.ProjectileFolder,newFileName + ".json"));
            listProjectiles.Items.Add("NewProjectile");
            listProjectiles.SelectedItem = listProjectiles.Items[listProjectiles.Items.Count - 1];
            selectedProjectile.Edit("name", newFileName);

            //Save projectile reference
            projectileDictionary.Add(newFileName,new List<string>());
            projectileDictionary.saveSelected();

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

            //Remove projectile reference
            projectileDictionary.Remove(name);
            projectileDictionary.saveSelected();
        }

        private void img_projectile_Click(object sender, EventArgs e)
        {
            if (listProjectiles.SelectedItems.Count == 0) return;
            selectImageDialog.ShowDialog();
        }

        private void selectImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var projectileName = listProjectiles.SelectedItems[0].ToString().Replace(" ","") + ".png";
            var projectileName = listProjectiles.SelectedItems[0].ToString() + ".png";
            lastImagePath = selectImageDialog.FileName;
            img_projectile.Image?.Dispose();
            img_projectile.Image = Image.FromFile(lastImagePath);
            File.Copy(lastImagePath,Path.Combine(Project.instance.projectPath,Resources.ProjectileFolder, projectileName),true);
        }

        private void dataGridProjectile_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Get row name - value
            var name = dataGridProjectile.Rows[e.RowIndex].Cells[1].Value.ToString();
            var value = dataGridProjectile.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (name == "name" && !value.IsValidKeyword())
            {
                MessageBox.Show("Cannot set projectile name as C# reserved keyword: " + value);
                dataGridProjectile.Rows[e.RowIndex].Cells[2].Value = selectedProjectile.FindValue("name");
                return;
            }

            //If renaming exist in the list dont rename
            if (listProjectiles.Items.Contains(value))
            {
                MessageBox.Show("Cannot set projectile name that already exist");
                return;
            }
            if (name == "name")
            {
                var prevName = selectedProjectile.FindValue("name");

                //Rename the projectile inside projectile.json
                projectileDictionary.RenameKey(prevName,value);

                //Save projectile to projectile.json
                projectileDictionary.saveSelected();
                
                //Dispose the image to rename it
                img_projectile.Image?.Dispose();
                
                //Rename projectile
                selectedProjectile.Rename(value);
                
                //Rename weapon
                selectedDamage.Rename(value);
                
                //Refresh list of projectiles
                RefreshList();
            }
            //Save projectile data to its json
            selectedProjectile.data.UpdateFromDataTable(this.dataGridProjectile.DataSource as DataTable);
            selectedProjectile.Save();

        }

        private void listProjectiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProjectiles.SelectedItems.Count == decimal.Zero) return;
            var name = listProjectiles.SelectedItems[0].ToString();

            //Get paths of both jsons
            var projectilePath = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder, name + ".json");
            var damagePath = Path.Combine(Project.instance.projectPath,Resources.ProjectileFolder, Resources.ProjectileWeaponFolder,name + ".json");

            //load up projectile model to table 
            selectedProjectile = new ModelToList<ProjectileModel>(projectilePath);
            dataGridProjectile.DataSource = selectedProjectile.data.ToDataTable();

            //load up weapon model to table 
            selectedDamage = new ModelToList<DamageModel>(damagePath);
            dataGridDamage.DataSource = selectedDamage.data.ToDataTable();

            //Get image from selected projectile
            var imagePath = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder,selectedProjectile.FindValue("name")+ ".png");
            img_projectile.Image?.Dispose();
            if (File.Exists(imagePath))
                img_projectile.Image = Image.FromFile(imagePath);
            else
                img_projectile.Image = null;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projectile and Weapon models are related");
        }

        private void dataGridDamage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //var name = dataGridDamage.Rows[e.RowIndex].Cells[1].Value.ToString();
            //var value = dataGridDamage.Rows[e.RowIndex].Cells[2].Value.ToString();

            //Save table to json
            selectedDamage.data.UpdateFromDataTable(this.dataGridDamage.DataSource as DataTable);
            selectedDamage.Save();
        }
    }
}
