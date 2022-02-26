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
using BloonTowerMaker.Properties;

namespace BloonTowerMaker.Logic
{
    class Compile
    {
        //TODO: compile stats view constructor
        public void CompileTower(Project project)
        {
            //Get all files as array of strings
            List<string> files = new List<string>();
            try
            {
                files.AddRange(Parser.ParsePaths());
                files.Add(Parser.ParseBase());
                files.Add(Parser.ParseMain());
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
                throw new Exception("Error Getting DLL: " + e.Message);
            }

            //Image include in project
            try
            {
                foreach (var directory in Directory.GetDirectories(project.projectPath))
                        parameters.EmbeddedResources.AddRange(Directory.GetFiles(directory, "*.png"));
            }
            catch (Exception e)
            {
                throw new Exception("Error compiling image: " + e.Message);
            }

            //Compile parameters
            parameters.IncludeDebugInformation = false;
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;
            parameters.TreatWarningsAsErrors = false;
            parameters.OutputAssembly = $"{project.projectName.Replace(" ", "")}.dll";
             
            //Compile
            CompilerResults results = provider.CompileAssemblyFromSource(parameters,files.ToArray());
            if (results.Errors.Count > 0)
            {
                foreach (var file in files)
                {
                    NotepadHelper.ShowMessage(file, "Error");
                }
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
