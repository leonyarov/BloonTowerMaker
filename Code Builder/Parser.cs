using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using BloonTowerMaker.Data;
using BloonTowerMaker.Properties;
using BTD_Mod_Helper.Api.Towers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BloonTowerMaker.Logic
{
    class Parser
    {
        private static Models models = new Models();

        //TODO: implement URLS
        public static string ParseMain()
        {
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
            var damageModel = new ModelToList<DamageModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(Resources.Base), Resources.TowerGlobalDamageJsonFile));

            StringBuilder file = new StringBuilder(Builder.BuildBase(Project.instance.projectName, baseModel.FindValue("DisplayName").RemoveWhiteSpace()));

            //Set variables inside the class
            StringBuilder vars = Builder.VariableBuilderFromData(baseModel.data, Builder.BuildVariable);
            file.Replace("/*VARIABLES*/", vars.ToString());

            //Build the base function
            var func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", BuilderStrings.TOWERMODEL_CONVENTION));

            //Assign projectiles
            var projectiles = ParseProjectileForPath(Resources.Base);
            func.Replace("/*PROJECTILES*/", projectiles);

            //Build function variables
            var funcCode = Builder.VariableBuilderFromData(towerModel.data, (data) => Builder.BuildFunctionVariable("towerModel",data), true);
            func.Replace("/*CODE*/", funcCode.ToString());
            
            //Build attack model variables
            funcCode = Builder.VariableBuilderFromData(attackModel.data,(data) => Builder.BuildFunctionVariable("towerModel.GetAttackModel()", data), true);
            func.Replace("/*CODE*/", funcCode.ToString());

            //Build foreach loop
            var loop = new StringBuilder(Builder.BuildLoop("weaponModel", "towerModel.GetWeapons()"));

            //Build weapon model inside loop
            funcCode = Builder.VariableBuilderFromData(weaponModel.data,(data) => Builder.BuildFunctionVariable("weaponModel", data),true);
            loop.Replace("/*CODE*/",funcCode.ToString());

            //Build damage model inside loop
            funcCode = Builder.VariableBuilderFromData(damageModel.data,(data) => Builder.BuildFunctionVariable("weaponModel.projectile.GetDamageModel()", data));
            loop.Replace("/*CODE*/",funcCode.ToString());
            
            //Place loop inside the function
            func.Replace("/*CODE*/", loop.ToString());

            //Finish Building Function
            file.Replace("/*FUNCTIONS*/", func.ToString());
            return file.ToString();

            //TODO: implement projectiles
        }

        public static List<string> ParsePaths()
        {
            List<string> sources = new List<string>(); //list of all generated files
            var baseName = (new ModelToList<ModTower>(Models.GetJsonPath(Resources.Base))).FindValue("DisplayName");
            foreach (var towerFolder in Directory.GetDirectories(Project.instance.projectPath))
            {
                if (towerFolder.Contains(Resources.Base) || !towerFolder.Contains("path_")) continue; //skip base
                var path = Path.GetFileName(towerFolder).Replace("path_","");
                var baseModel = new ModelToList<ModUpgrade>(Models.GetJsonPath(path));
                var towerModel = new ModelToList<TowerModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerModelJsonFile));
                var attackModel = new ModelToList<AttackModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerAttackJsonFile));
                var weaponModel = new ModelToList<WeaponModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerGlobalAttackJsonFile));
                var damageModel = new ModelToList<DamageModel>(Path.Combine(Project.instance.projectPath, Models.ParsePath(path), Resources.TowerGlobalDamageJsonFile));

                if (!baseModel.CanCompile())  continue; //Quit compiling file if is not compilable
                StringBuilder file = new StringBuilder(Builder.BuildPath(Project.instance.projectName, baseModel.FindValue("DisplayName").RemoveWhiteSpace(), baseName));

                //Set variables inside the class
                StringBuilder vars = Builder.VariableBuilderFromData(baseModel.data, Builder.BuildVariable);
                file.Replace("/*VARIABLES*/", vars.ToString());

                //Build the base function
                var func = new StringBuilder(Builder.BuildFunction("ApplyUpgrade", BuilderStrings.TOWERMODEL_CONVENTION));

                //Assign projectiles
                var projectiles = ParseProjectileForPath(path);
                func.Replace("/*PROJECTILES*/", projectiles);

                //Build function variables
                var funcCode = Builder.VariableBuilderFromData(towerModel.data, (data) => Builder.BuildFunctionVariable("towerModel", data), true);
                func.Replace("/*CODE*/", funcCode.ToString());

                //Build attack model variables
                funcCode = Builder.VariableBuilderFromData(attackModel.data, (data) => Builder.BuildFunctionVariable("towerModel.GetAttackModel()", data), true);
                func.Replace("/*CODE*/", funcCode.ToString());

                //Build foreach loop for global modifiers
                var loop = new StringBuilder(Builder.BuildLoop("weaponModel", "towerModel.GetWeapons()"));

                //Build weapon model inside loop
                funcCode = Builder.VariableBuilderFromData(weaponModel.data, (data) => Builder.BuildFunctionVariable("weaponModel", data),true);
                loop.Replace("/*CODE*/", funcCode.ToString());

                //Build damage model inside loop
                funcCode = Builder.VariableBuilderFromData(damageModel.data, (data) => Builder.BuildFunctionVariable("weaponModel.projectile.GetDamageModel()", data));
                loop.Replace("/*CODE*/", funcCode.ToString());

                //Place loop inside the function
                func.Replace("/*CODE*/", loop.ToString());

                //Finish Building Function (finalize)
                file.Replace("/*FUNCTIONS*/", func.ToString());
                sources.Add(file.ToString());
            }

            return sources;
        }

        public static string ParseProjectileClasses()
        {
            var projectileFolder = Directory.GetFiles(Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder), "*.json");
            var template = new StringBuilder(Builder.BuildProjectileDisplayTemplate(Project.instance.projectName));
            foreach (var projectile in projectileFolder)
            {
                var weaponFile = Path.Combine(Project.instance.projectPath, Resources.ProjectileWeaponFolder, Path.GetFileName(projectile));
                var projectileModel = new ModelToList<WeaponModel>(projectile);
                //var damageModel = new ModelToList<DamageModel>(weaponFile);
                var @class = Builder.BuildProjectileDisplayClass(Path.GetFileNameWithoutExtension(weaponFile),
                    projectileModel.FindValue("display"));
                template.Replace("/*CLASS*/", @class);
            }

            return template.ToString();
        }

        private static string ParseProjectileForPath(string path)
        {
            var projectileFile = (new Dictionary<string, List<string>>()).loadSelected();
            if (!projectileFile.Any(x => x.Value.Contains(path))) return string.Empty;
            StringBuilder projectile = new StringBuilder();
            projectile.Append("var wpn = towerModel.GetWeapon().Duplicate();");
            projectile.Append("foreach (var w in towerModel.GetWeapons()) towerModel.GetAttackModel().RemoveWeapon(w);");
            //Every projectile assigned to path
            int index = 0;
            foreach (var entry in projectileFile)
            {
                if (!projectileFile[entry.Key].Contains(path)) continue;
                
                //Paths
                var projectilePath =Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder, entry.Key + ".json");
                var weaponPath  = Path.Combine(Project.instance.projectPath, Resources.ProjectileFolder, Resources.ProjectileWeaponFolder,entry.Key + ".json");

                //Models
                var projectileModel = new ModelToList<ProjectileModel>(projectilePath);
                var damageModel = new ModelToList<WeaponModel>(weaponPath);

                //Set new weapon name
                var variableString = $"wpn{index++}";

                //Set the new weapon as duplicate
                var dupe = $"var {variableString} = wpn.Duplicate();";

                //Apped the duplicated weapon
                projectile.Append(dupe); 
                
                //Build variables of both models
                var proj = Builder.VariableBuilderFromData(projectileModel.data, (data) => Builder.BuildFunctionVariable(variableString + ".projectile",data),true);
                var dmg = Builder.VariableBuilderFromData(damageModel.data, (data) => Builder.BuildFunctionVariable(variableString + ".projectile.GetDamageModel()",data));

                //Append the variables
                projectile.Append(proj);
                projectile.Replace("/*CODE*/", dmg.ToString());

                //Set the projectile display
                projectile.Append($"{variableString}.projectile.ApplyDisplay<{entry.Key}>();");

                //Add the weapon to all weapons
                projectile.Append($"towerModel.GetAttackModel().AddWeapon({variableString});");
            }

            return projectile.ToString();
        }

        public static string ParseDisplayClass()
        {

            //Build template class for displays
            var template = new StringBuilder(Builder.BuildDisplayTemplate(Project.instance.projectName));
            //Get the base model
            var baseModel = new ModelToList<ModTower>(Models.GetJsonPath(Resources.Base));

            //Get the name of the base model
            var baseName = baseModel.FindValue("DisplayName");

            //Get every path folder
            foreach (var towerFolder in Directory.GetDirectories(Project.instance.projectPath, "path*"))
            {
                //Path to the texture file
                var texturePath = Path.Combine(towerFolder, Resources.TowerTexturesJsonFile);

                //Check if texture.json exist
                if (!File.Exists(texturePath)) continue;

                //Get texture file
                var textureFile = new Textures(texturePath);

                //Get texture data
                var textureData = textureFile.dataDictionary.First();

                //Extract path from folder name
                var path = Path.GetFileName(towerFolder).Replace("path_", "");

                var isBase = path == Resources.Base;
                StringBuilder textureClass;

                //Get texture for the base
                if (isBase)
                {
                    textureClass = new StringBuilder(Builder.BuildDisplayClass(
                        baseName, baseName, textureData.Key,
                        string.Join("", textureData.Value.ConvertAll(i => i.ToString()).ToArray()),
                        "0", "0", baseModel.FindValue("Texture")));
                }
                //Get texture for other paths
                else
                {
                var upgradeModel = new ModelToList<ModUpgrade>(Models.GetJsonPath(path));
                textureClass = new StringBuilder(Builder.BuildDisplayClass(
                    upgradeModel.FindValue("DisplayName"), baseName, textureData.Key,
                    string.Join("", textureData.Value.ConvertAll(i => i.ToString()).ToArray()),
                    Models.GetPathInt(upgradeModel.FindValue("Path")).ToString(), 
                    upgradeModel.FindValue("Tier"), upgradeModel.FindValue("Texture")));
                }

                template.Replace("/*CLASS*/", textureClass.ToString());
            }

            return template.ToString();
        }
    }
}
