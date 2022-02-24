using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonTowerMaker.Properties;
using Il2CppSystem;
using Newtonsoft.Json;
using Exception = System.Exception;
using String = System.String;

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

        public void Delete()
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception err)
            {
                throw new Exception($"Cannot Delete file at path {path}: " + err.Message);
            }

            var fileDir = Path.GetDirectoryName(path);
            var fileInDir = Directory.GetFiles(fileDir);
            var fileName = Path.GetFileNameWithoutExtension(path);
            foreach (var file in fileInDir)
            {
                if (!file.Contains(fileName)) continue;
                try
                {
                    File.Delete(file);
                }
                catch (Exception errException)
                {
                    throw new Exception($"Cannot Delete additional files to file {fileName}: {file} - " +
                                        errException.Message);
                }
            }
        }

        public void Rename(string newName)
        {
            if (newName == path) return;
            if (!newName.Contains(".json")) newName += ".json";
            var fileName = Path.GetFileNameWithoutExtension(path);
            var fileDir = Path.GetDirectoryName(path);
            var newFileName = Path.Combine(fileDir, newName);
            try
            {
                File.Move(path, newFileName); //Rename the file
                path = newFileName; //set new path as the current path
                var fileInDir = Directory.GetFiles(fileDir);
                foreach (var file in fileInDir)
                {
                    if (!file.Contains(fileName) || file == newFileName) continue;
                    try
                    {
                        var extension = Path.GetExtension(file);
                        File.Move(file, Path.Combine(fileDir,newName.Replace(".json","")) + extension);
                    }
                    catch (Exception errException)
                    {
                        throw new Exception($"Cannot Rename additional files to file {fileName}: {file} - " +
                                            errException.Message);
                    }
                }
            }
            catch (Exception errException)
            {
                throw new Exception($"Cannot rename {fileName} to {newFileName}" + errException.Message);
            }
        }

    }



}
