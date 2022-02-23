using BloonTowerMaker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assets.Scripts.Models;
using BloonTowerMaker.Properties;
using Newtonsoft.Json;

namespace BloonTowerMaker.Logic
{
    class Parser
    {
        private static Models models = new Models();

        //TODO: implement URLS
        public static string ParseMain()
        {
            var model = models.GetTowerModel(Resources.Base);
            StringBuilder file = new StringBuilder(Builder.BuildMain(Project.instance.projectName, Project.instance.version, Project.instance.author));
            StringBuilder vars = new StringBuilder();
            vars.Append(Builder.BuildVariable("string", "MelonInfoCsURL", "url1"));
            vars.Append(Builder.BuildVariable("string", "LatestURL", "url2"));
            file.Replace("/*VARIABLES*/", vars.ToString());
            return file.ToString() ;
        }

        public static string ParseBase()
        {
            var typeDictionary = Models.ExtractPropertiesFromTowerModel(); //types
            var dictionary = models.GetTowerModel(Resources.Base); // the base dictionary
            StringBuilder file = new StringBuilder(Builder.BuildBase(Project.instance.projectName));
            StringBuilder vars = new StringBuilder();
            var model = RemoveGeneralVariables(ref dictionary);
            file.Replace("$towerclass$",model["name"].Replace(" ",""));
            vars.Append(Builder.BuildVariable("string?", "TowerSet", model["towerSet"]));
            vars.Append(Builder.BuildVariable("string?", "BaseTower", $"TowerType.{model["baseTower"]}"));
            vars.Append(Builder.BuildVariable("string", "Description", model["description"]));
            vars.Append(Builder.BuildVariable("int", "Cost", model["cost"]));
            vars.Append(Builder.BuildVariable("int", "TopPathUpgrades", $"{Project.instance.TopPathUpgrade}"));
            vars.Append(Builder.BuildVariable("int", "MiddlePathUpgrades", $"{Project.instance.MiddlePathUpgrades}"));
            vars.Append(Builder.BuildVariable("int", "BottomPathUpgrades", $"{Project.instance.BottomPathUpgrades}"));

            file.Replace("/*VARIABLES*/", vars.ToString()); //Place path variables 
            //vars.Append(Builder.BuildVariable("ParagonMode", "ParagonMode", "ParagonMode.None"));
            StringBuilder func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", "TowerModel towerModel"));
            vars.Clear(); //free string builder
            foreach (var entry in dictionary)
            {
                if (string.IsNullOrWhiteSpace(entry.Value)) continue; //skip empty strings
                vars.Append(Builder.BuildFunctionVariable("towerModel", entry.Key, entry.Value));
            }

            func.Replace("/*CODE*/", vars.ToString());
            file.Replace("/*FUNCTIONS*/", func.ToString());
            return file.ToString();
        }

        public static string[] ParsePath()
        {
            List<string> sources = new List<string>();
            var lastTower = "";
            if (!Directory.Exists(Project.instance.projectPath)) throw new DirectoryNotFoundException("Cant find project folder");
            try
            {
                foreach (var towerfile in Directory.GetFiles(Project.instance.projectPath, Resources.TowerPathJsonFile, SearchOption.AllDirectories))
                {
                    lastTower = towerfile;
                    if (towerfile.Contains("000")) continue; //skip base file
                    //TODO: json legit check
                    var text = File.ReadAllText(towerfile);
                    var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string,string>>(text);
                    if (string.IsNullOrWhiteSpace(jsonDictionary["cost"]) || string.IsNullOrWhiteSpace(jsonDictionary["name"])) continue;;
                    var dict = RemoveGeneralVariables(ref jsonDictionary);
                    StringBuilder file = new StringBuilder(Builder.BuildPath(Project.instance.projectName,dict["name"].Replace(" ","")));
                    StringBuilder vars = new StringBuilder();
                    file.Replace("$basetower$", models.GetTowerModel("000")["name"].Replace(" ", ""));
                    vars.Append(Builder.BuildVariable("int", "Cost", $"{dict["cost"]}"));
                    vars.Append(Builder.BuildVariable("string", "Description", $"{dict["description"]}"));
                    vars.Append(Builder.BuildVariable("int", "Path", $"{dict["path"]}"));
                    vars.Append(Builder.BuildVariable("int", "Tier", $"{dict["tier"]}"));
                    file.Replace("/*VARIABLES*/", vars.ToString());

                    StringBuilder func = new StringBuilder();
                    func.Append(Builder.BuildFunction("ApplyUpgrade", "TowerModel towerModel"));
                    vars.Clear(); //free string builder
                    foreach (var entry in jsonDictionary)
                    {
                        if (string.IsNullOrWhiteSpace(entry.Value)) continue; //skip empty strings
                        vars.Append(Builder.BuildFunctionVariable("towerModel", entry.Key, entry.Value));
                    }

                    func.Replace("/*CODE*/", vars.ToString());
                    file.Replace("/*FUNCTIONS*/", func.ToString());
                    sources.Add(file.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Cannot open .json file: " + lastTower);
            }

            return sources.ToArray();
        }

        private static Dictionary<string, string> RemoveGeneralVariables(ref Dictionary<string, string> dict)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "cost", dict["cost"] },
                { "description", dict["description"] },
                { "name", dict["name"] },
                { "path", dict["path"] },
                { "tier", dict["tier"] },
                { "towerSet", dict["towerSet"] },
                { "baseTower", dict["baseTower"] },
                { "Priority", dict["Priority"] },
            };
            dict.Remove("cost");
            dict.Remove("tier");
            dict.Remove("description");
            dict.Remove("name");
            dict.Remove("path");
            dict.Remove("towerSet");
            dict.Remove("baseTower");
            dict.Remove("Priority");
            return dictionary;
        }
    }
}
