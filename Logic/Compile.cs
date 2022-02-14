using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.IO;
using BloonTowerMaker.Data;

namespace BloonTowerMaker.Logic
{
    class Compile
    {
        public void CompileTower()
        {
            string[] files = {Parser.ParseMain(),Parser.ParseBase() };
            CSharpCodeProvider cscp = new CSharpCodeProvider(
                new Dictionary<string,string>() { {"CompilerVersion", Parser.ParseMain()} }
                );
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("mscorelib.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("NKHook6.dll");
            parameters.ReferencedAssemblies.Add("BTD_Mod_Helper.dll");
            parameters.ReferencedAssemblies.Add("MelonLoader.dll");
            parameters.ReferencedAssemblies.Add("Il2Cppmscorlib.dll");
            parameters.IncludeDebugInformation = false;
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = $"{new Models().GetBaseModel().name.Replace(" ","")}.dll";

            CompilerResults results = cscp.CompileAssemblyFromSource(parameters,files);
            if (results.Errors.Count > 0)
            {
                var error = "";
                foreach (CompilerError CompErr in results.Errors)
                {
                    error += 
                        "Line number " + CompErr.Line +
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine;
                }
                throw new Exception(error);
            }
           
        }
    }
}
