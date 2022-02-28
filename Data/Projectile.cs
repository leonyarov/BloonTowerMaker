using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonTowerMaker.Properties;
using System.IO;
using Assets.Scripts.Models.Towers.Weapons;
using Newtonsoft.Json;

namespace BloonTowerMaker.Data
{
    public class Projectile
    {
        private List<Dictionary<string, string>> projectile;
    

        public Dictionary<string,string> GetModel()
        {
            return projectile[0];
        }

        public Dictionary<string, string> GetValues()
        {
            return projectile[1];
        }

        public void SetValues(Dictionary<string,string> src)
        {
            projectile[1].SetValues(src);
        }
        public void SetModel(Dictionary<string, string> src)
        {
            projectile[0].SetValues(src);
        }


        public Projectile(string fileName = "NewProjectile", bool load = false)
        {
            projectile = new List<Dictionary<string, string>>();
            projectile.Add(extractModelAsDictionary());
            var valuesDictionary = new Dictionary<string, string>();

            if (load)
            {
                projectile.Add(new Dictionary<string, string>());
               Load(fileName);
            }
            else
            {
                foreach (var modelEntry in GetModel())
                    valuesDictionary[modelEntry.Key] = "";
                valuesDictionary["name"] = fileName;
                projectile.Add(valuesDictionary);   
                Save();
            }
        }

        public Dictionary<string, string> Load(string fileName)
        {
            var proj = Project.instance;
            if (!fileName.Contains(".json")) fileName += ".json";
            try
            {
                var path = System.IO.Path.Combine(proj.projectPath,Resources.ProjectileFolder, fileName);
                var json = File.ReadAllText(path);
                SetValues(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
            }
            catch (Exception err)
            {
                throw new Exception($"Error reading {fileName} projectile file: " + err.Message);
            }

            return GetValues();
        }
        public void Save()
        {
            try
            {
                var serializeObject = JsonConvert.SerializeObject(GetValues());
                File.WriteAllText(System.IO.Path.Combine(Project.instance.projectPath,Resources.ProjectileFolder,GetValues()["name"] + ".json"), serializeObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot write projectile file: "+ ex.Message);
            }
        }

        public static IEnumerable<Projectile> getAllProjectiles()
        {
            var path = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder);
            var filePaths = Directory.GetFiles(path, "*.json");
            foreach (var file in filePaths)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                yield return new Projectile(fileName,true);
            }
        }

        public static IEnumerable<string> getProjectileNames()
        {
            foreach (var projectile in getAllProjectiles())
            {
                var name = projectile.GetValues()["name"];
                yield return name;
            }
        }



        public Dictionary<string, string> extractModelAsDictionary()
        {
            return Models.ExtractProperties<WeaponModel>();
        }

        public static void Delete(string projectileName)
        {
            var imgName = projectileName;
            if (!projectileName.Contains(".json")) 
                projectileName += ".json";
            var path = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder, projectileName);
            try
            {
                File.Delete(path);
                var imagePath = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder, imgName.Replace(" ","") + ".png");
                if (File.Exists(imagePath))
                    File.Delete(imagePath);
            }
            catch (Exception err)
            {
                throw new Exception($"Cannot Delete {projectileName}" + err.Message);
            }
        }

        //OH SHIT THIS IS A FRICKING AMOGUS REFERENCE
    }
}
