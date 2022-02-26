using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloonTowerMaker.Data
{
    public static class DictionaryExtensions
    {
        public static DataTable ToDataTable<T>(this Projectile projectile)
        {
            var dt = new DataTable();
            dt.Columns.Add("Type", typeof(T));
            dt.Columns.Add("Name", typeof(T));
            foreach (var keyValuePair in projectile.GetModel())
                dt.Rows.Add(keyValuePair.Value,keyValuePair.Key);
            dt.Columns.Add("Value", typeof(T));
            var values = projectile.GetValues();
            foreach (DataRow dtRow in dt.Rows)
            {
                var key = dtRow[1].ToString();
                dtRow[2] = values[key];
            }

            return dt;
        }
        public static DataTable ToDataTable(this List<List<string>> model)
        {
            var dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            foreach (var variable in model)
                dt.Rows.Add(variable[0],variable[1],variable[2]);
            dt.Columns[0].ReadOnly = dt.Columns[1].ReadOnly = true;
            return dt;
        }
        public static DataTable ToDataTableWithCheckbox(this List<string> model)
        {
            var dt = new DataTable();
            dt.Columns.Add("Projectile Name", typeof(string));
            dt.Columns.Add("Enabled", typeof(bool));
            foreach (var variable in model)
                    dt.Rows.Add(variable, false);
            dt.Columns[0].ReadOnly = true;
            return dt;
        }
        public static void UpdateFromDataTable(this Dictionary<string, string> dictionary,
            DataTable table)
        {
            foreach (DataRow tableRow in table.Rows)
            {
                var key = tableRow[1].ToString();
                var value = tableRow[2].ToString();
                dictionary[key] = value;
            }
        }
        public static void UpdateFromDataTable(this List<List<string>> model,
            DataTable table)
        {
            foreach (DataRow tableRow in table.Rows)
            {
                var type = tableRow[0].ToString();
                var name = tableRow[1].ToString();
                var value = tableRow[2].ToString();
                var list = new List<string> { type, name, value};
                var index = model.FindIndex(x => x.Contains(name));
                model[index] = list;
            }
        }

        public static void SetValues(this Dictionary<string, string> valuesDictionary, Dictionary<string,string> copyFromDictionary)
        {
            foreach (var key in copyFromDictionary.Keys.ToList())
                valuesDictionary[key] = copyFromDictionary[key];
        }


        public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic,
            TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }
    }
}
