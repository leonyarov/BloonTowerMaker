using BloonTowerMaker.Properties;
using Newtonsoft.Json;
using System;
using System.IO;

namespace BloonTowerMaker.Data
{
    class Models
    {
        private string dpath = Settings.Default.LastTowerPath;

        public BaseModel GetBaseModel(string path)
        {
            BaseModel json;
            validate(path);
            var jsonpath = $"{dpath}/tower_{path}/data_{path}.json";
            StreamReader r = new StreamReader(jsonpath);
            try
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<BaseModel>(jsonString);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot read file of path: " + path);
            }
            finally
            {
                r.Close();
            }
            return json;
        }

        public void UpdateBaseModel(BaseModel model, string path)
        {
            var jsonpath = $"{dpath}/tower_{path}/data_{path}.json";
            var json = JsonConvert.SerializeObject(model);
            
            if (json == null)
            {
                throw new Exception("Failed to convert data to json");   
            }
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
                var model = new BaseModel();
                model.path = model.cost = model.top = model.buttom = model.middle = model.tier = "0";
                var json = JsonConvert.SerializeObject(model);
                File.WriteAllText(datapath, json);
            }
        }
        public static int[] PathLengths()
        {
            Models models = new Models();
            int[] paths = new int[] {0,0,0};
            for (int i = 1; i < 5; i++)
            {
                if (models.PathExist(models.GetBaseModel($"{i}00")))
                    paths[0]++;
            }
            for (int i = 1; i < 5; i++)
            {
                if(models.PathExist(models.GetBaseModel($"0{i}0")))
                    paths[1]++;
            }
            for (int i = 1; i < 5; i++)
            {
                if (models.PathExist(models.GetBaseModel($"00{i}")))
                    paths[2]++;
            }
            return paths;
        }

        public static string getImagesPath(string path)
        {
            return Path.Combine(Settings.Default.LastTowerPath, $"tower_{path}/images/");
        }
        public static string getTowerPath(string path)
        {
            return $"../../userfiles/tower_{path}/";
        }

        public bool PathExist(BaseModel model)
        {
            return model.description != null && model.cost != null && model.name != null;
        }

        public static string GetPathRow(string path)
        {
            if (path[0] != '0')
                return "TOP";
            return path[1] != '0' ? "MIDDLE" : "BOTTOM";
        }

        public  bool isAllowed(string path)
        {
            var @base = GetBaseModel("000");
            var t = int.Parse(@base.top);
            var m = int.Parse(@base.middle);
            var b = int.Parse(@base.buttom);
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


    }
}
