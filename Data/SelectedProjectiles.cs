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
    public static class SelectedProjectiles
    {
        //private Dictionary<string, List<string>> selectedProjectiles;

        //Load the dictionary from file
        public static Dictionary<string, List<string>> loadSelected(this Dictionary<string, List<string>> dict )
        {
            var path = Path.Combine(Project.instance.projectPath, Resources.ProjectileJson);
            try
            {
                var json = File.ReadAllText(path);
                dict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json) ?? new Dictionary<string, List<string>>();
                return dict;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot save projectile.json: " + e.Message);
            }
        }

        //Write the dictionary to file
        public static void saveSelected(this Dictionary<string, List<string>> dict)
        {
            var path = Path.Combine(Project.instance.projectPath, Resources.ProjectileJson);

            try
            {
                var json = JsonConvert.SerializeObject(dict);
                File.WriteAllText(path,json);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot save projectile.json: " + e.Message);
            }
        }

    }
}
