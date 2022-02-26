using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Weapons;
using Newtonsoft.Json;


namespace BloonTowerMaker.Data
{
    public class CombinedModel
    {
        public Dictionary<string, List<List<string>>> models;
        public string path;

        /// <summary>
        /// 
        ///var towerModel = Models.ExtractProperties<TowerModel>();
        ///var weaponModel = Models.ExtractProperties<WeaponModel>();
        ///var projectileModel = Models.ExtractProperties<ProjectileModel>();
        ///var attackModel = Models.ExtractProperties<AttackModel>();
        /// </summary>
        public CombinedModel(Dictionary<string,Dictionary<string, string>> models, string path)
        {
            this.path = path;
            this.models = new Dictionary<string, List<List<string>>>();
            if (!File.Exists(path))
            {
                foreach (var dict in models)
                {
                    var model =new List<List<string>>();
                    foreach (var item in dict.Value)
                    {
                        var variable = new List<string>();
                        variable.Add(item.Value);
                        variable.Add(item.Key);
                        variable.Add(String.Empty);
                        model.Add(variable);
                    }
                    this.models[dict.Key] = model;
                }

                Save();
            }

            Load();
        }

        public void Save()
        {
            try
            {
                var serializeObject = JsonConvert.SerializeObject(models);
                File.WriteAllText(path, serializeObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot write projectile file: " + ex.Message);
            }
        }

        public void Load()
        {
            try
            {
                var json = File.ReadAllText(path);
                models = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(json);
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
                        File.Move(file, Path.Combine(fileDir, newName.Replace(".json", "")) + extension);
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
