using BloonTowerMaker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Weapons;
using BloonTowerMaker.Properties;
using BTD_Mod_Helper.Api.Towers;
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

        //public static string ParseBase()
        //{
        //    var dictionary = models.GetTowerModel(Resources.Base); // the base dictionary
        //    StringBuilder file = new StringBuilder(Builder.BuildBase(Project.instance.projectName));
        //    StringBuilder vars = new StringBuilder();
        //    var model = RemoveGeneralVariables(ref dictionary);
        //    file.Replace("$towerclass$",model["name"].Replace(" ",""));

        //    //Build Variables for base tower properties
        //    vars.Append(Builder.BuildVariable("string?", "TowerSet", model["towerSet"]));
        //    vars.Append(Builder.BuildVariable("string?", "BaseTower", $"TowerType.{model["baseTower"]}"));
        //    vars.Append(Builder.BuildVariable("string", "Description", model["description"]));
        //    vars.Append(Builder.BuildVariable("int", "Cost", model["cost"]));
        //    vars.Append(Builder.BuildVariable("int", "TopPathUpgrades", $"{Project.instance.TopPathUpgrade}"));
        //    vars.Append(Builder.BuildVariable("int", "MiddlePathUpgrades", $"{Project.instance.MiddlePathUpgrades}"));
        //    vars.Append(Builder.BuildVariable("int", "BottomPathUpgrades", $"{Project.instance.BottomPathUpgrades}"));
        //    vars.Append(Builder.BuildVariable("ParagonMode", "ParagonMode", "ParagonMode.None"));

        //    file.Replace("/*VARIABLES*/", vars.ToString()); //Place path variables 
        //    StringBuilder func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", "TowerModel towerModel"));
        //    vars.Clear(); //free string builder
        //    foreach (var entry in dictionary)
        //    {
        //        if (string.IsNullOrWhiteSpace(entry.Value)) continue; //skip empty strings
        //        vars.Append(Builder.BuildFunctionVariable("towerModel", entry.Key, entry.Value));
        //    }

        //    func.Replace("/*CODE*/", vars.ToString());
        //    file.Replace("/*FUNCTIONS*/", func.ToString());
        //    return file.ToString();
        //}

        public static string ParseBase()
        {
            var baseModel = new ModelToList<ModTower>(Models.GetJsonPath(Resources.Base));
            var towerModel = new ModelToList<TowerModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(Resources.Base), Resources.TowerModelJsonFile));
            var attackModel = new ModelToList<AttackModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(Resources.Base), Resources.TowerAttackJsonFile));
            var weaponModel = new ModelToList<WeaponModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(Resources.Base), Resources.TowerGlobalAttackJsonFile));

            StringBuilder file = new StringBuilder(Builder.BuildBase(Project.instance.projectName, baseModel.FindValue("DisplayName").RemoveWhiteSpace()));

            //Set variables inside the class
            StringBuilder vars = Builder.VariableBuilderFromData(baseModel.data, Builder.BuildVariable);
            file.Replace("/*VARIABLES*/", vars.ToString());

            //Build the base function
            var func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", BuilderStrings.TOWERMODEL_CONVENTION));
            var funcCode = Builder.VariableBuilderFromData(towerModel.data, (data) => Builder.BuildFunctionVariable("towerModel",data), true);
            func.Replace("/*CODE*/", funcCode.ToString());
            //Build attack model variables
            funcCode = Builder.VariableBuilderFromData(attackModel.data,(data) => Builder.BuildFunctionVariable("towerModel.GetAttackModel()", data), true);
            func.Replace("/*CODE*/", funcCode.ToString());
            //Build foreach loop
            var loop = new StringBuilder(Builder.BuildLoop("weaponModel", "tower.GetWeapons()"));
            funcCode = Builder.VariableBuilderFromData(weaponModel.data,(data) => Builder.BuildFunctionVariable("weaponModel", data));
            loop.Replace("/*LOOP_CODE*/",funcCode.ToString());
            func.Replace("/*CODE*/", loop.ToString());

            //Finish Building Function
            file.Replace("/*FUNCTIONS*/", func.ToString());
            return file.ToString();

            //TODO: implement projectiles
        }

        public static List<string> ParsePaths()
        {
            List<string> sources = new List<string>(); //list of all generated files
            var lastTower = "";
            var baseName = (new ModelToList<ModTower>(Models.GetJsonPath(Resources.Base))).FindValue("DisplayName");
            foreach (var towerFolder in Directory.GetDirectories(Project.instance.projectPath))
            {
                if (towerFolder.Contains(Resources.Base)) continue; //skip base
                var path = Path.GetFileName(towerFolder).Replace("path_","");
                lastTower = towerFolder; //save last tower folder
                var baseModel = new ModelToList<ModTower>(Models.GetJsonPath(path));
                var towerModel = new ModelToList<TowerModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerModelJsonFile));
                var attackModel = new ModelToList<AttackModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerAttackJsonFile));
                var weaponModel = new ModelToList<WeaponModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerGlobalAttackJsonFile));

                if (string.IsNullOrWhiteSpace(baseModel.FindValue("Cost")) || )
                StringBuilder file = new StringBuilder(Builder.BuildPath(Project.instance.projectName, baseModel.FindValue("DisplayName").RemoveWhiteSpace(), baseName));

                //Set variables inside the class
                StringBuilder vars = Builder.VariableBuilderFromData(baseModel.data, Builder.BuildVariable);
                file.Replace("/*VARIABLES*/", vars.ToString());

                //Build the base function
                var func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", BuilderStrings.TOWERMODEL_CONVENTION));
                var funcCode = Builder.VariableBuilderFromData(towerModel.data, (data) => Builder.BuildFunctionVariable("towerModel", data), true);
                func.Replace("/*CODE*/", funcCode.ToString());
                //Build attack model variables
                funcCode = Builder.VariableBuilderFromData(attackModel.data, (data) => Builder.BuildFunctionVariable("towerModel.GetAttackModel()", data), true);
                func.Replace("/*CODE*/", funcCode.ToString());
                //Build foreach loop
                var loop = new StringBuilder(Builder.BuildLoop("weaponModel", "tower.GetWeapons()"));
                funcCode = Builder.VariableBuilderFromData(weaponModel.data, (data) => Builder.BuildFunctionVariable("weaponModel", data));
                loop.Replace("/*LOOP_CODE*/", funcCode.ToString());
                func.Replace("/*CODE*/", loop.ToString());

                //Finish Building Function
                file.Replace("/*FUNCTIONS*/", func.ToString());
                return file.ToString();
            }

        }
        public static string[] ParsePath()
        {
            List<string> sources = new List<string>();
            var lastTower = "";
            if (!Directory.Exists(Project.instance.projectPath)) throw new DirectoryNotFoundException("Cant find project folder");
            try
            {
                foreach (var towerFile in Directory.GetFiles(Project.instance.projectPath, Resources.TowerPathJsonFile, SearchOption.AllDirectories))
                {
                    lastTower = towerFile;
                    if (towerFile.Contains("000")) continue; //skip base file
                    //TODO: json legit check
                    var text = File.ReadAllText(towerFile);
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
