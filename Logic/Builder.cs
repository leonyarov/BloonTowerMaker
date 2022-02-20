using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BloonTowerMaker.Logic
{
    internal class Builder
    {
        

        private static string Stringify(string src, bool inClass = false)
        {
            return inClass ? $@"""{src}""" : $"\"{src}\"";
        }

        public static string BuildDisplay(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.DISPLAY_CLASS);
            stringBuilder.Replace("$class$", name.Replace(" ",""));
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

        public static string BuildMain(string tower, string version , string author)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.MAIN_CLASS);
            stringBuilder.Replace("$tower$", tower.Replace(" ",""));
            stringBuilder.Replace("$towername$", Stringify(tower,true));
            stringBuilder.Replace("$version$", Stringify(version,true));
            stringBuilder.Replace("$author$", Stringify(author,true));
            return stringBuilder.ToString();
        }

        public static string BuildBase(string tower)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.BASE_CLASS);
            stringBuilder.Replace("$tower$", tower.Replace(" ", ""));
            return stringBuilder.ToString();
        }

        public static string BuildPath(string tower, string upgrade)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.PATH_CLASS);
            stringBuilder.Replace("$tower$", tower.Replace(" ", ""));
            stringBuilder.Replace("$upgrade$", upgrade.Replace(" ", ""));
            return stringBuilder.ToString();
        }

        public static string BuildFunction(string name, string @params)
        {
            StringBuilder stringBuilder = new StringBuilder(BuilderStrings.FUNCTION);
            stringBuilder.Replace("$name$", name);
            stringBuilder.Replace("$params$", @params);
            return stringBuilder.ToString();
        }
    }
}
