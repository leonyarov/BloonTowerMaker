using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonTowerMaker.Logic
{
    internal class Builder
    {
        private const string VARIABLE = @"public override $type$ $name$ {get { return $value$;}}";
        private const string FUNCTION_VARIABLE = @"$type$ $name$ {get { return $value$;}}";
        private const string MAIN_CLASS = @"using BTD_Mod_Helper;
                                            using MelonLoader;
                                            [assembly: MelonInfo(typeof($tower$.Main), $towername$, $version$, $author$)]
                                            [assembly: MelonGame(""Ninja Kiwi "", ""BloonsTD6"")]
                                            namespace $tower$
                                            {
                                                    public class Main : BloonsTD6Mod
                                                    {
                                                       /*VARIABLES*/
                                                    }
                                            }";
        private const string BASE_CLASS = @"using Assets.Scripts.Models.Towers;
                                            using Assets.Scripts.Models.TowerSets;
                                            using BTD_Mod_Helper;
                                            using BTD_Mod_Helper.Api.Towers;
                                            using BTD_Mod_Helper.Extensions;
                                            using MelonLoader;
                                            namespace $tower$
                                            {
                                                    public class Base : BloonsTD6Mod
                                                    {
                                                       /*VARIABLES*/
                                                       /*FUNCTIONS*/
                                                    }
                                            }";
        private const string PATH_CLASS = @"using Assets.Scripts.Models.Towers;
                                            using Assets.Scripts.Models.Towers.Behaviors.Emissions;
                                            using Assets.Scripts.Models.Towers.Weapons.Behaviors;
                                            using BTD_Mod_Helper.Api.Towers;
                                            using BTD_Mod_Helper.Extensions;
                                            namespace $tower$
                                            {
                                                    public class $upgrade$ : BloonsTD6Mod
                                                    {
                                                       /*VARIABLES*/
                                                       /*FUNCTIONS*/
                                                    }
                                            }";

        private const string FUNCTION = @"public override void $name$($params$) {
                                            /*CODE*/
                                         }";

        public static string Stringify(string src, bool inClass = false)
        {
            return inClass ? $@"""{src}""" : $"\"{src}\"";
        }
        public static string BuildVariable(string type, string name, string value)
        {
            StringBuilder stringBuilder = new StringBuilder(VARIABLE);
            stringBuilder.Replace("$type$", type);
            stringBuilder.Replace("$name$", name);
            if (type == "string" && !value.Contains("\\\"")) //check if string has special \"
                value = Stringify(value);
            stringBuilder.Replace("$value$", value);

            return stringBuilder.ToString();
        }

        //TODO: implement version and author
        public static string BuildMain(string tower, string version , string author)
        {
            StringBuilder stringBuilder = new StringBuilder(MAIN_CLASS);
            stringBuilder.Replace("$tower$", tower.Replace(" ",""));
            stringBuilder.Replace("$towername$", Stringify(tower,true));
            stringBuilder.Replace("$version$", Stringify("0.0.1",true));
            stringBuilder.Replace("$author$", Stringify("Unknown Author",true));
            return stringBuilder.ToString();
        }

        public static string BuildBase(string tower)
        {
            StringBuilder stringBuilder = new StringBuilder(BASE_CLASS);
            stringBuilder.Replace("$tower$", tower.Replace(" ", ""));
            return stringBuilder.ToString();
        }

        public static string BuildPath(string tower, string upgrade)
        {
            StringBuilder stringBuilder = new StringBuilder(PATH_CLASS);
            stringBuilder.Replace("$tower$", tower.Replace(" ", ""));
            stringBuilder.Replace("$upgrade$", upgrade);
            return stringBuilder.ToString();
        }

        public static string BuildFunction(string name, string @params)
        {
            StringBuilder stringBuilder = new StringBuilder(FUNCTION);
            stringBuilder.Replace("$name$", name);
            stringBuilder.Replace("$params$", @params);
            return stringBuilder.ToString();
        }
    }
}
