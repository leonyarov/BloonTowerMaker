using BTD_Mod_Helper;
using MelonLoader;

[assembly: MelonInfo(typeof(/*tower*/.Main), "/*towername*/", "0.2.1", "/*author*/")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace /*tower*/
{
    public class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL { get { return "/*MelonInfoCsURL*/"; } }
        public override string LatestURL { get { return "/*LatestURL*/"; } }
    }   
}

