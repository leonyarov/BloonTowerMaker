using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonTowerMaker.Data;
using Il2CppSystem.Runtime.Remoting.Messaging;

namespace BloonTowerMaker.Logic
{
    internal class Builder
    {
        

        private static string Stringify(string src, bool inClass = false)
        {
            return inClass ? $@"""{src}""" : $"\"{src}\"";
        }

        public static string BuildProjectileDisplayClass(string name,string textureName)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.PROJECTILE_DISPLAY_CLASS);
            stringBuilder.Replace("$class$", name.RemoveWhiteSpace());
            stringBuilder.Replace("$TextureName$", Stringify(textureName));
            return stringBuilder.ToString();
        }

        public static string BuildProjectileDisplayTemplate(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.DISPLAY_CLASS_TEMPLATE);
            stringBuilder.Replace("$tower$", name);
            return stringBuilder.ToString();
        }

        public static string BuildDisplayClass(
            string tower, string basetower, string towertype, string typepath, string row, string tier,  string texturename)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.DISPLAY_TEXTURE_CLASS);
            stringBuilder.Replace("$tower$", tower.RemoveWhiteSpace());
            stringBuilder.Replace("$basetower$", basetower.RemoveWhiteSpace());
            stringBuilder.Replace("$towertype$", towertype.RemoveWhiteSpace());
            stringBuilder.Replace("$top$", typepath[0].ToString());
            stringBuilder.Replace("$mid$", typepath[1].ToString());
            stringBuilder.Replace("$bot$", typepath[2].ToString());
            stringBuilder.Replace("$row$", row.RemoveWhiteSpace());
            stringBuilder.Replace("$tier$", tier.RemoveWhiteSpace());
            stringBuilder.Replace("$texturename$", texturename.RemoveWhiteSpace());

            return stringBuilder.ToString();
        }
        public static string BuildVariable(string type, string name, string value)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.VARIABLE);
            stringBuilder.Replace("$type$", type.Replace("?", ""));
            stringBuilder.Replace("$name$", name);
            if (type == "string" && !type.Contains('?'))
                value = Stringify(value);
            stringBuilder.Replace("$value$", value);

            return stringBuilder.ToString();
        }

        public static string BuildVariable(List<string> data)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.VARIABLE);
            stringBuilder.Replace("$type$", data.GetModelType());
            stringBuilder.Replace("$name$", data.GetModelName());
            stringBuilder.Replace("$value$", data.ParseValue());
            return stringBuilder.ToString();
        }
        public static string BuildMain(string tower, string version , string author)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.MAIN_CLASS);
            stringBuilder.Replace("$tower$", tower.RemoveWhiteSpace());
            stringBuilder.Replace("$towername$", Stringify(tower,true));
            stringBuilder.Replace("$version$", Stringify(version,true));
            stringBuilder.Replace("$author$", Stringify(author,true));
            return stringBuilder.ToString();
        }

        public static string BuildBase(string towerName, string towerClass)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.BASE_CLASS);
            stringBuilder.Replace("$tower$", towerName.RemoveWhiteSpace());
            stringBuilder.Replace("$towerclass$", towerClass.RemoveWhiteSpace());
            return stringBuilder.ToString();
        }

        public static string BuildPath(string tower, string upgrade, string baseTower)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.PATH_CLASS);
            stringBuilder.Replace("$tower$", tower.RemoveWhiteSpace());
            stringBuilder.Replace("$upgrade$", upgrade.RemoveWhiteSpace());
            stringBuilder.Replace("$basetower$", baseTower.RemoveWhiteSpace());
            return stringBuilder.ToString();
        }

        public static string BuildFunction(string name, string @params)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.FUNCTION);
            stringBuilder.Replace("$name$", name);
            stringBuilder.Replace("$params$", @params);
            return stringBuilder.ToString();
        }

        public static string BuildLoop(string item, string collection)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.FOREACH_LOOP);
            stringBuilder.Replace("$item$", item);
            stringBuilder.Replace("$collection$", collection);
            return stringBuilder.ToString();
        }

        public static string BuildFunctionVariable(string function,string properties, string value)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.FUNCTION_VARIABLE);
            stringBuilder.Replace("$name$", function.RemoveWhiteSpace());
            stringBuilder.Replace("$properties$", properties.RemoveWhiteSpace());
            stringBuilder.Replace("$value$", value);
            return stringBuilder.ToString();
        }
        /// <summary>
        /// $function$.$properties$ = $value$;"
        /// </summary>
        /// <param name="function">Function name to append</param>
        /// <param name="variable">Propery and value</param>
        /// <returns>finished string</returns>
        public static string BuildFunctionVariable(string function, List<string> variable)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.FUNCTION_VARIABLE);
            stringBuilder.Replace("$name$", function.RemoveWhiteSpace());
            stringBuilder.Replace("$properties$", variable.GetModelName().RemoveWhiteSpace());
            stringBuilder.Replace("$value$", variable.ParseValue());
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Multiple variables based on function given
        /// </summary>
        /// <param name="data">variables to work with</param>
        /// <param name="func">func to pass</param>
        /// <param name="appendMore">appends /*CODE*/ in the end</param>
        /// <returns>StringBuilder with variables</returns>
        public static StringBuilder VariableBuilderFromData(List<List<string>> data, Func<List<string>,string> func, bool appendMore = false)
        {
            StringBuilder code = new StringBuilder();
            foreach (var variable in data)
            {
                if (!variable.IsValidValue() || !variable.CanInclude()) continue;
                code.Append(func(variable));
            }
            if (appendMore) code.Append("/*CODE*/");
            return code;
        }
    }
}
