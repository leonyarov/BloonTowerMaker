using BloonTowerMaker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloonTowerMaker.Logic
{
    class Parser
    {
        private static Models models = new Models();

        //TODO: implement URLS
        public static string ParseMain()
        {
            var model = models.GetBaseModel("000");
            StringBuilder file = new StringBuilder(Builder.BuildMain(model.name,"a","a"));
            StringBuilder vars = new StringBuilder();
            vars.Append(Builder.BuildVariable("string", "MelonInfoCsURL", "url1"));
            vars.Append(Builder.BuildVariable("string", "LatestURL", "url2"));
            file.Replace("/*VARIABLES*/", vars.ToString());
            return file.ToString() ;
        }

        public static string ParseBase()
        {
            var model = models.GetBaseModel("000");
            StringBuilder file = new StringBuilder(Builder.BuildBase(model.name));
            StringBuilder vars = new StringBuilder();
            vars.Append(Builder.BuildVariable("string", "TowerSet", model.set));
            vars.Append(Builder.BuildVariable("string", "BaseTower", model.basetower));
            vars.Append(Builder.BuildVariable("string", "Description", model.description));
            vars.Append(Builder.BuildVariable("int", "Cost", model.cost));
            vars.Append(Builder.BuildVariable("int", "TopPathUpgrades", model.top));
            vars.Append(Builder.BuildVariable("int", "MiddlePathUpgrades", model.middle));
            vars.Append(Builder.BuildVariable("int", "BottomPathUpgrades", model.buttom));
            vars.Append(Builder.BuildVariable("ParagonMode", "ParagonMode", "ParagonMode.None"));
            StringBuilder func = new StringBuilder(Builder.BuildFunction("ModifyBaseTowerModel", "TowerModel towerModel"));
            file.Replace("VARIABLES", vars.ToString());
            file.Replace("FUNCTIONS", func.ToString());
            return file.ToString();
        }

        public static string[] ParsePath()
        {
            List<string> sources = new List<string>();
            var pathfiles = $"{Environment.CurrentDirectory}/../../userfiles";
            var tower_name = models.GetBaseModel("000").name;
            if (!Directory.Exists(pathfiles)) throw new DirectoryNotFoundException("Cant find project folder");
            foreach (var towerfile in Directory.GetFiles(pathfiles, "*.json", SearchOption.AllDirectories))
            {
                if (towerfile.Contains("000")) continue; //skip base file
                var model = models.GetBaseModel(towerfile.Replace("data_",""));
                StringBuilder file = new StringBuilder(Builder.BuildPath(tower_name,model.name));
                StringBuilder vars = new StringBuilder();
                vars.Append(Builder.BuildVariable("int", "Cost", model.cost));
                vars.Append(Builder.BuildVariable("string", "Description", model.description));
                file.Replace("/*VARIABLES*/", vars.ToString());
                sources.Append(file.ToString());
            }
            return sources.ToArray();
        }
    }
}
