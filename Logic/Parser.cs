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
            file = file.Replace("/*tower*/", model.name.Replace(" ",""));
            file = file.Replace("/*towername*/",model.name);
            file = file.Replace("/*author*/", "user");
            file = file.Replace("/*MelonInfoCsURL*/","url");
            file = file.Replace("/*LatestURL*/", "tower update url");
            //MessageBox.Show(file);
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
            file = file.Replace("/*tower*/", model.name.Replace(" ", ""));
            file = file.Replace("/*TowerSet*/",model.set);
            file = file.Replace("/*BaseTower*/",model.basetower);
            file = file.Replace("/*Cost*/",model.cost);
            file = file.Replace("/*TopPathUpgrades*/",model.top);
            file = file.Replace("/*MiddlePathUpgrades*/",model.middle);
            file = file.Replace("/*BottomPathUpgrades*/", model.buttom);
            file = file.Replace("/*Description*/", model.description);
            file = file.Replace("/*ParagonMode*/", model.paragon);
            file = file.Replace("/*range*/", model.range);
            file = file.Replace("/*attack_range*/", "0");
            file = file.Replace("/*projectile*/", "null");
            file = file.Replace("/*pierce*/", "0");
            //file.Replace("",model.);
            //MessageBox.Show(file);

            return file;
        }

        //TODO: test this function 
        public static string[] ParsePath()
        {
            List<string> sources = new List<string>();
            var pathfiles = $"{Environment.CurrentDirectory}/../../userfiles";
            if (!Directory.Exists(pathfiles)) throw new DirectoryNotFoundException("Cant find project folder");
            foreach (var towerfile in Directory.GetFiles(pathfiles, "*.json", SearchOption.AllDirectories))
            {
                if (towerfile.Contains("000")) continue; //skip base file
                var model = models.GetTemplateModel(towerfile.Replace("data_",""));
                var basefile = $"{Environment.CurrentDirectory}/../../res/csTemplate/TemplateModel.cs";
                try
                {
                    StreamReader r = new StreamReader(basefile);
                    sources.Add(r.ReadToEnd());
                    r.Close();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error Parsing {towerfile} data: {e.Message}");
                }
            }
            return sources.ToArray();
        }
    }
}
