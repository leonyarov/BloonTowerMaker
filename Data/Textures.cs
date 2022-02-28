using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BloonTowerMaker.Data
{
    public class Textures
    {
        public Dictionary<string, List<int>> dataDictionary;
        private string path;

        public Textures(string path)
        {
            dataDictionary = new Dictionary<string, List<int>>();
            this.path = path;
            if (!File.Exists(path))
            {
                dataDictionary["DartMonkey"] = new List<int>(){0,0,0};
                Save();
            }
            Load();
        }

        public void Save()
        {
            try
            {
                var serializeObject = JsonConvert.SerializeObject(dataDictionary);
                File.WriteAllText(path, serializeObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot write texture file: " + ex.Message);
            }
        }

        public void Load()
        {
            try
            {
                var json = File.ReadAllText(path);
                dataDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(json);
            }
            catch (Exception err)
            {
                throw new Exception($"Error reading {Path.GetFileNameWithoutExtension(path)} texture file: " + err.Message);
            }
        }

    }
}
