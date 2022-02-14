using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BloonTowerMaker.Data
{
    class Models
    {
        private string fpath = "../../res/towerfiles/<>.json";

        public BaseModel GetBaseModel()
        {
            StreamReader r = new StreamReader(fpath.Replace("<>","base"));
            string jsonString = r.ReadToEnd();
            var json = JsonConvert.DeserializeObject<BaseModel>(jsonString);
            r.Close();
            return json;
        } 
        public TemplateModel GetTemplateModel(string path)
        {
            validate(path);
            StreamReader r = new StreamReader(fpath.Replace("<>", path));
            string jsonString = r.ReadToEnd();
            var json = JsonConvert.DeserializeObject<TemplateModel>(jsonString);
            r.Close();
            return json;
        }

        public void UpdateBaseModel(BaseModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(fpath.Replace("<>","base"),json);
        }
        public void UpdateTemplateModel(TemplateModel model, string path)
        {
            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(fpath.Replace("<>", path),json);
        }

        private void validate(string path)
        {
            StreamReader r;
            try
            {
                r = new StreamReader(fpath.Replace("<>", path));
            }
            catch (Exception e)
            {
                r = new StreamReader(fpath.Replace("<>", "template"));
                var template = r.ReadToEnd();
                File.WriteAllText(fpath.Replace("<>", path), template);
            }
            r.Close();
        }
    }
}
