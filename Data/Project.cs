using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BloonTowerMaker.Properties;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BloonTowerMaker.Data
{
    public class Project
    {
        public string author;
        public string version;
        public string projectName;
        public string projectPath;

        public Project(string projectPath, string projectName, string version, string author)
        {
            this.projectPath = projectPath ?? "";
            this.projectName = projectName ?? "New Tower";
            this.version = version ?? "1.0.0";
            this.author = author ?? "Unknown Author";
        }

        public static Project New(bool justFile = false)
        {
            using (var form = new NewProject())
            {
                if (justFile) form.path.Text = Settings.Default.LastTowerPath;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Save(form.proj);
                    return form.proj;
                }
                Application.Exit();
            }

            return null;
        }
        public static Project Load()
        {
            var last = Settings.Default?.LastTowerPath ?? GetFolder();
            var path = Path.Combine(last, Resources.ProjectMainFile);
            if (!File.Exists(path))
                return New(true);
            var proj = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Project>(proj);
        }

        public static void Save(Project project)
        {
            var last = Settings.Default?.LastTowerPath ?? GetFolder();
            var path = Path.Combine(last, Resources.ProjectMainFile);
            var json = JsonConvert.SerializeObject(project);
            File.WriteAllText(path, json);
        }

        public static string GetFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Settings.Default.LastTowerPath = fbd.SelectedPath;
                    Settings.Default.Save();
                    return fbd.SelectedPath;
                }
                else if (result == DialogResult.Cancel || result == DialogResult.Abort)
                    return Settings.Default.LastTowerPath ?? "";
                else
                    throw new Exception("Error retrieving folder");
            }
        }
    }
}
