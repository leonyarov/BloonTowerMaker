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

namespace BloonTowerMaker.Logic
{
    class Parser
    {
        private static Models models = new Models();

        //TODO: implement URLS
        public static string ParseMain(Project project)
        {
            var model = models.GetBaseModel(Resources.Base);
            StringBuilder file = new StringBuilder(Builder.BuildMain(project.projectName,project.version,project.author));
            StringBuilder vars = new StringBuilder();
            vars.Append(Builder.BuildVariable("string", "MelonInfoCsURL", "url1"));
            vars.Append(Builder.BuildVariable("string", "LatestURL", "url2"));
            file.Replace("/*VARIABLES*/", vars.ToString());
            return file.ToString() ;
        }

        public static string ParseBase(Project project)
        {
            var model = models.GetBaseModel(Resources.Base);
            StringBuilder file = new StringBuilder(Builder.BuildBase(project.projectName));
            StringBuilder vars = new StringBuilder();
            vars.Append(Builder.BuildVariable("string?", "TowerSet", model.set));
            vars.Append(Builder.BuildVariable("string?", "BaseTower", model.basetower));
            vars.Append(Builder.BuildVariable("string", "Description", model.description));
            vars.Append(Builder.BuildVariable("int", "Cost", model.cost));
            vars.Append(Builder.BuildVariable("int", "TopPathUpgrades", model.top));
            vars.Append(Builder.BuildVariable("int", "MiddlePathUpgrades", model.middle));
            vars.Append(Builder.BuildVariable("int", "BottomPathUpgrades", model.buttom));
            //vars.Append(Builder.BuildVariable("ParagonMode", "ParagonMode", "ParagonMode.None"));
            StringBuilder func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", "TowerModel towerModel"));
            file.Replace("/*VARIABLES*/", vars.ToString());
            file.Replace("/*FUNCTIONS*/", func.ToString());
            return file.ToString();
        }

        public static string[] ParsePath()
        {
            List<string> sources = new List<string>();
            var pathfiles = $"{Environment.CurrentDirectory}/../../userfiles";
            var tower_name = models.GetBaseModel("000").name;
            if (!Directory.Exists(pathfiles)) throw new DirectoryNotFoundException("Cant find project folder");
            try
            {
                foreach (var towerfile in Directory.GetFiles(pathfiles, "*.json", SearchOption.AllDirectories))
                {
                    var path = towerfile.Substring(towerfile.Length - 8, 3);
                    if (path == "000" || !models.isAllowed(path)) continue; //skip base file
                    var model = models.GetBaseModel(path);
                    if (!models.PathExist(model)) continue; //if files is not edited enought skip it
                    StringBuilder file = new StringBuilder(Builder.BuildPath(tower_name, model.name));
                    StringBuilder vars = new StringBuilder();
                    vars.Append(Builder.BuildVariable("int", "Cost", model.cost));
                    vars.Append(Builder.BuildVariable("string", "Description", model.description));
                    vars.Append(Builder.BuildVariable("int", "Path", model.path));
                    vars.Append(Builder.BuildVariable("int", "Tier", model.tier));
                    StringBuilder func = new StringBuilder();
                    func.Append(Builder.BuildFunction("ApplyUpgrade", "TowerModel tower"));

                    file.Replace("/*VARIABLES*/", vars.ToString());
                    file.Replace("/*FUNCTIONS*/", func.ToString());
                    sources.Add(file.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Cannot open .json file");
            }

            return sources.ToArray();
        }
    }
}
