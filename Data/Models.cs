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
        private string dpath = "../../userfiles";


        public BaseModel GetBaseModel()
        {
            validate("000");
            var jsonpath = $"{dpath}/tower_000/data_000.json";
            StreamReader r = new StreamReader(jsonpath);
            string jsonString = r.ReadToEnd();
            var json = JsonConvert.DeserializeObject<BaseModel>(jsonString);
            r.Close();
            return json;
        } 
        public TemplateModel GetTemplateModel(string path)
        {
            validate(path);
            var jsonpath = $"{dpath}/tower_{path}/data_{path}.json";
            StreamReader r = new StreamReader(jsonpath);
            string jsonString = r.ReadToEnd();
            var json = JsonConvert.DeserializeObject<TemplateModel>(jsonString);
            r.Close();
            return json;
        }

        public void UpdateBaseModel(BaseModel model)
        {
            var jsonpath = $"{dpath}/tower_000/data_000.json";
            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(jsonpath, json);
        }
        public void UpdateTemplateModel(TemplateModel model, string path)
        {
            var jsonpath = $"{dpath}/tower_{path}/data_{path}.json";
            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(jsonpath, json);
        }

        private void validate(string path)
        {
            var filepath = $"{dpath}/tower_{path}";
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            if (!Directory.Exists(filepath + "/images"))
                Directory.CreateDirectory(filepath + "/images");

            var datapath = $"{filepath}/data_{path}.json";
            if (!File.Exists(datapath))
            {
                StreamReader r = new StreamReader(fpath.Replace("<>", "template"));
                var template = r.ReadToEnd();
                File.WriteAllText(datapath, template);
                r.Close();
            }
        }

        public static string getImagesPath(string path)
        {
            return $"../../userfiles/tower_{path}/images/";
        }
        public static string getTowerPath(string path)
        {
            return $"../../userfiles/tower_{path}/";
        }
}
}
