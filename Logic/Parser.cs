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
        public static string ParseMain()
        {
            BaseModel model = models.GetBaseModel();
            var basefile = $"{Environment.CurrentDirectory}/../../res/csTemplate/MainTemplate.cs";
            var file = "";
            try
            {
                StreamReader r = new StreamReader(basefile);
                file = r.ReadToEnd();
                r.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Parsing Main", e.ToString());
                return null;
            }
            file.Replace("/*tower*/", model.name.Replace(" ",""));
            file.Replace("/*towername*/",model.name);
            file.Replace("/*author*/","user");
            file.Replace("/*MelonInfoCsURL*/","url");
            file.Replace("/*LatestURL*/","tower update url");
            return file;
        }

        public static string ParseBase()
        {
            var model = models.GetBaseModel();
            var basefile = $"{Environment.CurrentDirectory}/../../res/csTemplate/BaseTemplate.cs";
            var file = "";
            try
            {
                StreamReader r = new StreamReader(basefile);
                file = r.ReadToEnd();
                r.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Parsing Base file", e.ToString());
                return null;
            }
            file.Replace("/*tower*/", model.name.Replace(" ", ""));
            file.Replace("/*TowerSet*/",model.set);
            file.Replace("/*BaseTower*/",model.basetower);
            file.Replace("/*Cost*/",model.cost);
            file.Replace("/*TopPathUpgrades*/",model.top);
            file.Replace("/*MiddlePathUpgrades*/",model.middle);
            file.Replace("/*BottomPathUpgrades*/", model.buttom);
            file.Replace("/*Description*/", model.description);
            file.Replace("/*ParagonMode*/", model.paragon);
            file.Replace("/*range*/", "0");
            file.Replace("/*attack_range*/", "0");
            file.Replace("/*projectile*/", "null");
            file.Replace("/*pierce*/", "0");
            //file.Replace("",model.);
            return file;
        }

        public static void ParsePath()
        {

        }
    }
}
