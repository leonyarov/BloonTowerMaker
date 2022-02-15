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
            CSharpCodeProvider csc = new CSharpCodeProvider();
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            //parameters.ReferencedAssemblies.Add("mscorlib.dll");
            //parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("NKHook6.dll");
            parameters.ReferencedAssemblies.Add("BloonsTD6 Mod Helper.dll");
            parameters.ReferencedAssemblies.Add("MelonLoader.dll");
            parameters.ReferencedAssemblies.Add("Il2Cppmscorlib.dll");
            parameters.ReferencedAssemblies.Add("UnhollowerBaseLib.dll");
            //parameters.ReferencedAssemblies.Add("NinjaKiwi.LiNK.dll");
            //parameters.ReferencedAssemblies.Add("Unity.ResourceManager.dll");
            parameters.ReferencedAssemblies.Add("UnityEngine.CoreModule.dll");
            parameters.ReferencedAssemblies.Add("Assembly-CSharp.dll");
            parameters.IncludeDebugInformation = false;
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;
            parameters.TreatWarningsAsErrors = false;
            parameters.OutputAssembly = $"{new Models().GetBaseModel().name.Replace(" ","")}.dll";
             
            CompilerResults results = provider.CompileAssemblyFromSource(parameters,files);
            if (results.Errors.Count > 0)
            {
                var error = "";
                foreach (CompilerError CompErr in results.Errors)
                {
                    error += CompErr.FileName + 
                        ": Line number " + CompErr.Line+ " " + CompErr.Column+
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine;
                }
                throw new Exception(error);
            }
           
        }
    }
}
