using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BloonTowerMaker.Properties;
using System.IO;
using System.Windows.Forms;
using Assets.Scripts.Models.Towers;
using Newtonsoft.Json;

namespace BloonTowerMaker.Data
{
    public class Project
    {
        public string author;
        public string version;
        public string projectName;
        public string projectPath;
        public string baseTower;
        public int TopPathUpgrade, MiddlePathUpgrades, BottomPathUpgrades;


        public Project(string projectPath, string projectName, string version, string author)
        {
            this.projectPath = projectPath ?? "";
            this.projectName = projectName ?? "NewTower";
            this.version = version ?? "1.0.0";
            this.author = author ?? "Unknown Author";
            TopPathUpgrade = MiddlePathUpgrades = BottomPathUpgrades = 0;
            instance = this;
            baseTower = "TowerType.DartMonkey";
        }

        public static Project instance = null;

        public static void GenerateProjectFiles(string initialDirectory)
        {
            //Create Path files
            for (var i = 1; i <= 5; i++)
            {
                var towerFolder = Path.Combine(initialDirectory, $"path_{i}00");
                Directory.CreateDirectory(towerFolder);
            }
            for (var i = 1; i <= 5; i++)
            {
                var towerFolder = Path.Combine(initialDirectory, $"path_0{i}0");
                Directory.CreateDirectory(towerFolder);
            }
            for (var i = 1; i <= 5; i++)
            {
                var towerFolder = Path.Combine(initialDirectory, $"path_00{i}");
                Directory.CreateDirectory(towerFolder);
            }
            //Create paragon and base folder
            //Directory.CreateDirectory(Path.Combine(initialDirectory, "path_555")); //TODO: Enable this when paragons supported
            Directory.CreateDirectory(Path.Combine(initialDirectory, "path_000"));
            //Create projectile folder
            Directory.CreateDirectory(Path.Combine(initialDirectory, Resources.ProjectileFolder));
            //Create weapon folder inside projectile folder
            Directory.CreateDirectory(Path.Combine(initialDirectory, Resources.ProjectileFolder, Resources.ProjectileWeaponFolder));
            //Create project.json
            File.Create(Path.Combine(initialDirectory, Resources.ProjectileJson));
            //Create projectile.json
            //File.Create(Path.Combine(initialDirectory, Resources.ProjectMainFile));
        }
        public static Project New(bool pathFromLast = false)
        {
            //Create new init form
            using (var form = new NewProject())
            {
                if (pathFromLast) form.path.Text = Settings.Default.LastTowerPath;
                //

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GenerateProjectFiles(instance.projectPath);
                    Save();
                    return form.proj;
                }
                else
                    Environment.Exit(0); //Exit completely if window closed
            }

            return null;
        }
        public static Project Load()
        {
            //Get last used path or open folder
            var last = Settings.Default.LastTowerPath ?? GetFolder(); 
            var path = Path.Combine(last, Resources.ProjectMainFile);
            //Create new project if main project does not exist
            if (!File.Exists(path))
                return New(true);
            //Load project.json from folder
            var proj = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Project>(proj);
        }
        public static Project LoadFromRecent(int index)
        {
            var last = Settings.Default.RecentPaths[index];
            var path = Path.Combine(last, Resources.ProjectMainFile);
            if (!File.Exists(path))
                return New(true);
            var proj = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Project>(proj);
        }

        public static void Save()
        {

            var last = Settings.Default?.LastTowerPath ?? GetFolder();
            var path = Path.Combine(last, Resources.ProjectMainFile);
            var json = JsonConvert.SerializeObject(instance);
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
                    AddToRecent(fbd.SelectedPath);
                    return fbd.SelectedPath;
                }
                else if (result == DialogResult.Cancel || result == DialogResult.Abort)
                    return Settings.Default.LastTowerPath ?? "";
                else
                    throw new Exception("Error retrieving folder");
            }
        }

        private static void AddToRecent(string value)
        {
            if (!Settings.Default.RecentPaths.Contains(value))
                Settings.Default.RecentPaths.Add(value);
            if (Settings.Default.RecentPaths.Count > Settings.Default.MaxRecentPaths)
                Settings.Default.RecentPaths.RemoveAt(1);
            Settings.Default.Save();
        }

    }
}
