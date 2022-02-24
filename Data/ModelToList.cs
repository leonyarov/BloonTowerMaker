using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonTowerMaker.Properties;
using Newtonsoft.Json;

namespace BloonTowerMaker.Data
{
    public class ModelToList<T>
    {
        public List<List<string>> data;
        private string path;

        public ModelToList(string path)
        {
            data = new List<List<string>>();
            this.path = path;
            if (!File.Exists(path))
            {
                var extracted = Models.ExtractProperties<T>();
                foreach (var keyValuePair in extracted)
                {
                    var variable = new List<string>();
                    variable.Add(keyValuePair.Value);
                    variable.Add(keyValuePair.Key);
                    variable.Add(String.Empty);
                    data.Add(variable);
                }
                Save();
            }
            Load();
        }

        public List<string> Find(string entry)
        {
            return data.Find(x => x[1] == entry);
        }

        public string FindValue(string entry)
        {
            return Find(entry)[2];
        }

        public void Edit(string entry, string value)
        {
            data[data.IndexOf(Find(entry))][2] = value;
            Save();
        }

        public void Save()
        {
            try
            {
                var serializeObject = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, serializeObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot write projectile file: " + ex.Message);
            }
        }

        public void Load()
        {
            var proj = Project.instance;
            try
            {
                var json = File.ReadAllText(path);
                data = JsonConvert.DeserializeObject<List<List<string>>>(json);
            }
            catch (Exception err)
            {
                throw new Exception($"Error reading {Path.GetFileNameWithoutExtension(path)} projectile file: " + err.Message);
            }
        }

    }



}
