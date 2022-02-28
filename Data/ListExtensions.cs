using System.Collections.Generic;

namespace BloonTowerMaker.Data
{
    public static class ListExtensions
    {

        /// <summary>
        /// Get type of ModelToList data list entry
        /// </summary>
        /// <param name="data">List of values</param>
        /// <returns>The type of the model</returns>
        public static string GetModelType(this List<string> data)
        {
            return data[0];
        }

        /// <summary>
        /// Get name of ModelToList data list entry
        /// </summary>
        /// <param name="data">List of values</param>
        /// <returns>The name of the model</returns>
        public static string GetModelName(this List<string> data)
        {
            return data[1];
        }

        /// <summary>
        /// Get value of ModelToList data list entry
        /// </summary>
        /// <param name="data">List of values</param>
        /// <returns>The value of the model</returns>
        public static string GetModelValue(this List<string> data)
        {
            return data[2];
        }

        /// <summary>
        /// Parse value from a table by type
        /// </summary>
        /// <param name="data">data to check</param>
        /// <returns>string parsed to its type to put inside a stringbuilder</returns>
        public static string ParseValue(this List<string> data)
        {
            if (data.GetModelName().Equals("TowerSet"))
                return data.GetModelValue();
            if (data.GetModelName().Equals("BaseTower"))
                return $"TowerType.{data.GetModelValue()}";
            switch (data.GetModelType())
            {
                case "string":
                    return $"\"{data.GetModelValue()}\"";
                case "bool":
                    return data.GetModelValue().ToLower();
                case "float":
                    return data.GetModelValue() + 'f';
                default: 
                    return data.GetModelValue();
            }
        }


        /// <summary>
        /// Do not include special types
        /// </summary>
        public static bool CanInclude(this List<string> data)
        {
            var r1 = data.GetModelType().Equals("image");
            return !r1;
        }

        /// <summary>
        /// Check if data is viable to use in the compiler
        /// </summary>
        /// <param name="data">data list</param>
        /// <returns>True: if data is not empty value</returns>
        public static bool IsValidValue(this List<string> data)
        {
            return !string.IsNullOrWhiteSpace(data.GetModelValue());
        }
    }

    public static class StringExtensions
    {
        public static string RemoveWhiteSpace(this string str)
        {
            return str.Replace(" ", "");
        }
    }

}
