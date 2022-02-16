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
            //Get all files as array of strings
            List<string> files = new List<string>();
            try
            {
                files.Add(Parser.ParseMain());
                files.Add(Parser.ParseBase());
                files.AddRange(Parser.ParsePath());
            } catch (Exception e) {throw e;}
            //Create provider
            //CSharpCodeProvider csc = new CSharpCodeProvider();
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            try
            {
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
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error getting library files",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw e;
            }

            //Compile parameters
            parameters.IncludeDebugInformation = false;
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;
            parameters.TreatWarningsAsErrors = false;
            parameters.OutputAssembly = $"{new Models().GetBaseModel().name.Replace(" ","")}.dll";
             
            //Compile
            CompilerResults results = provider.CompileAssemblyFromSource(parameters,files.ToArray());
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
