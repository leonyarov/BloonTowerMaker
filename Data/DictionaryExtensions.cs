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

        public static void SetValues(this Dictionary<string, string> valuesDictionary, Dictionary<string,string> copyFromDictionary)
        {
            foreach (var key in copyFromDictionary.Keys.ToList())
                valuesDictionary[key] = copyFromDictionary[key];
        }
    }
}
