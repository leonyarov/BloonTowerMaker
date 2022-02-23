using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonTowerMaker.Logic
{
    internal class BuilderStrings
    {
        public const string VARIABLE = @"public override $type$ $name$ {get { return $value$;}}";
        public const string FUNCTION_VARIABLE = @"$name$.$properties$ = $value$;";
        public const string MAIN_CLASS = @"using BTD_Mod_Helper;
                                            using MelonLoader;
                                            using System.Reflection;
                                            using System.Runtime.InteropServices;
                                            using System.Runtime.CompilerServices;
                                            [assembly: MelonInfo(typeof($tower$.Main), $towername$, $version$, $author$)]
                                            [assembly: MelonGame(""Ninja Kiwi"", ""BloonsTD6"")]
                                            [assembly: AssemblyTitle(""BloonTowerMaker"")]
                                            [assembly: AssemblyDescription("""")]
                                            [assembly: AssemblyConfiguration("""")]
                                            [assembly: AssemblyCompany("""")]
                                            [assembly: AssemblyProduct(""BloonTowerMaker"")]
                                            [assembly: AssemblyCopyright(""Copyright ©  2022"")]
                                            [assembly: AssemblyTrademark("""")]
                                            [assembly: AssemblyCulture("""")]
                                            [assembly: ComVisible(false)]
                                            [assembly: AssemblyVersion(""1.0.0.0"")]
                                            [assembly: AssemblyFileVersion(""1.0.0.0"")]
                                            namespace $tower$
                                            {
                                                    public class Main : BloonsTD6Mod
                                                    {
                                                       /*VARIABLES*/
                                                        public override void OnApplicationStart()
                                                        {
                                                            LoggerInstance.Msg(""$tower$ In Shop mod loaded"");
                                                        }
                                                    }
                                                    
                                            }
";
        public const string BASE_CLASS = @"using Assets.Scripts.Models.Towers;
                                            using Assets.Scripts.Models.TowerSets;
                                            using BTD_Mod_Helper;
                                            using BTD_Mod_Helper.Api.Towers;
                                            using BTD_Mod_Helper.Extensions;
                                            using Assets.Scripts.Simulation.SMath;
                                            using Assets.Scripts.Unity.Display;
                                            using BTD_Mod_Helper.Api.Display;
                                            using MelonLoader;
                                            namespace $tower$
                                            {
                                                    public class $towerclass$ : ModTower
                                                    {
                                                       /*VARIABLES*/
                                                       /*FUNCTIONS*/
                                                    }
                                            }";
        public const string PATH_CLASS = @"using Assets.Scripts.Models.Towers;
                                            using Assets.Scripts.Models.Towers.Behaviors.Emissions;
                                            using Assets.Scripts.Models.Towers.Weapons.Behaviors;
                                            using BTD_Mod_Helper.Api.Towers;
                                            using BTD_Mod_Helper.Extensions;
                                            using Assets.Scripts.Simulation.SMath;
                                            using Assets.Scripts.Unity.Display;
                                            using BTD_Mod_Helper.Api.Display;
                                            namespace $tower$.Upgrades
                                            {
                                                    public class $upgrade$ : ModUpgrade<$basetower$>
                                                    {
                                                       /*VARIABLES*/
                                                       /*FUNCTIONS*/
                                                    }
                                            }";

        public const string FUNCTION = @"public override void $name$($params$) {
                                            /*CODE*/
                                         }
                                        /*FUNCTIONS*/";

        public const string DISPLAY_CLASS = @" public class $class$ : ModDisplay
                                        {
                                            public override string BaseDisplay => Generic2dDisplay;

                                            public override void ModifyDisplayNode(UnityDisplayNode node)
                                            {
                                                Set2DTexture(node, nameof($class$));
                                            }
                                        } 
                                        /*DISPLAYS*/";
    }
}
