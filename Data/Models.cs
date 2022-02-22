using BloonTowerMaker.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Models.Towers;

namespace BloonTowerMaker.Data
{
    class Models
    {
        public Dictionary<string, string> GetTowerModel(string path)
        {
            var jsonPath = Path.Combine(Project.instance.projectPath, ParsePath(path), Resources.TowerPathJsonFile);
            if (!File.Exists(jsonPath))
                UpdateBaseModel(getTowerModelAsDictionary(),path);
            var file = File.ReadAllText(jsonPath);
            var json = JsonConvert.DeserializeObject<Dictionary<string,string>>(file);
            return json;
        }

        public static string ParsePath(string path)
        {
            return $"path_{path}";
        }

        public void UpdateBaseModel(Dictionary<string,string> dictionary, string path)
        {
            var jsonPath = Path.Combine(Project.instance.projectPath, ParsePath(path), Resources.TowerPathJsonFile);
            var json = JsonConvert.SerializeObject(dictionary);
            if (json == null)
                throw new Exception("Failed to convert data to json");   
            File.WriteAllText(jsonPath, json);
        }

        public bool ModelIsLegit(Dictionary<string,string> dictionary)
        {
            //TODO: check if the model is legit by cost, description etc (described in github)
            throw new NotImplementedException();
        }

        public static string GetPathRow(string path)
        {
            if (path[0] != '0')
                return "TOP";
            return path[1] != '0' ? "MIDDLE" : "BOTTOM";
        }

        public  bool isAllowed(string path)
        {
            var @base = Project.instance;
            var t = @base.TopPathUpgrade;
            var m = @base.MiddlePathUpgrades;
            var b = @base.BottomPathUpgrades;
            var tier = GetPathTier(path);
            var row = GetPathRow(path);
            switch (row)
            {
                case "TOP" when tier <= t:
                case "MIDDLE" when tier <= m:
                case "BOTTOM" when tier <= b:
                    return true;
                default:
                    return false;
            }
        }

        public static int GetPathTier(string path)
        {
            foreach (var t in path)
            {
                if (t == '0') continue;
                return int.Parse(t.ToString());
            }

            return 0;
        }

        //Get TowerModel class as dictionary of type - name variables
        public static Dictionary<string, string> getTowerModelAsDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var key in ExtractPropertiesFromTowerModel().Keys)
                dict.Add(key,String.Empty);
            return dict;
        }

        public static Dictionary<string, string> ExtractPropertiesFromTowerModel()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var t = typeof(TowerModel).GetProperties();
            foreach (var propertyInfo in t)
            {
                try
                {
                    var key = propertyInfo.Name;
                    var value = propertyInfo.PropertyType.Name;
                    var cmp = StringComparison.CurrentCultureIgnoreCase;
                    if (!value.Equals(nameof(String), cmp) && !value.Equals(nameof(Single), cmp) &&
                        !value.Equals(nameof(Int32), cmp) && !value.Equals(nameof(Boolean), cmp)) continue;
                    dict.Add(key, value);
                }
                catch
                {
                    continue; //If the type is not valid and throws an error
                }
            }
            dict.Add("description","String"); //add missing variable
            dict.Add("path","Int32");
            dict.Add("baseTower", "String");
            return dict;
        }


    }
}
