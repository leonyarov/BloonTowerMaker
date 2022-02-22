using BloonTowerMaker.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BloonTowerMaker.Properties;
using System.IO;
namespace BloonTowerMaker
{
    public partial class ProjectileEditor : Form
    {
        private string lastImagePath;
        /// <summary>
        /// key - projectile name, value - projectile image path
        /// </summary>
        public ProjectileEditor()
        {
            InitializeComponent();
        }

        private void input_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)) //The latter is for enabling control keys like CTRL and backspace
            {
                e.Handled = true;
            }
        }
        void RefreshList()
        {
            try
            {
                listProjectiles.Items.Clear();
                listProjectiles.Items.AddRange(Projectile.Load().Keys.ToArray());
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
            Projectile.Save();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(input_name.Text) || string.IsNullOrWhiteSpace(lastImagePath))
                return;
            var dest = System.IO.Path.Combine(
                Project.instance.projectPath,
                Resources.ProjectileFolder,
                $"{input_name.Text}.png");

            try
            {
                System.IO.File.Copy(selectImageDialog.FileName, dest);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            Projectile.projectiles.Add(input_name.Text,dest);
            Projectile.Save();
            RefreshList();

            img_projectile.Image?.Dispose();
            img_projectile.Image = null;
            input_name.Clear();
            lastImagePath = String.Empty;

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (listProjectiles.SelectedItems.Count != 1) return;
            var path = Projectile.projectiles[listProjectiles.Items[listProjectiles.SelectedIndex].ToString()];
            Projectile.projectiles.Remove(listProjectiles.Items[listProjectiles.SelectedIndex].ToString());
            listProjectiles.Items.RemoveAt(listProjectiles.SelectedIndex);
            File.Delete(path);

        }

        private void img_projectile_Click(object sender, EventArgs e)
        {
            selectImageDialog.ShowDialog();
        }

        private void selectImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lastImagePath = selectImageDialog.FileName;
            img_projectile.Image = Image.FromFile(lastImagePath);
        }
    }
}
