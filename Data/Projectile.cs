using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonTowerMaker.Properties;
using System.IO;
using Newtonsoft.Json;

namespace BloonTowerMaker.Data
{
    internal class Projectile
    {
        public static Dictionary<string, string> projectiles;

        public static Dictionary<string, string> Load()
        {
            var proj = Project.instance;
            try
            {
                var path = System.IO.Path.Combine(proj.projectPath, Resources.ProjectileJson);
                var json = File.ReadAllText(path);
                projectiles = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch
            {
                throw new Exception($"Error reading {Resources.ProjectileJson} file");
            }

            return projectiles ?? (projectiles = new Dictionary<string, string>());
        }

        public static void Save()
        {
            try
            {
                var serializeObject = JsonConvert.SerializeObject(projectiles);
                File.WriteAllText(System.IO.Path.Combine(Project.instance.projectPath,Resources.ProjectileJson), serializeObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot save {Resources.ProjectileJson} file: "+ ex.Message);
            }
        }
    }
}
