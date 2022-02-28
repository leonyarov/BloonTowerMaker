using BloonTowerMaker.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assets.Scripts.Simulation;
using BloonTowerMaker.Properties;
using Mono.Cecil;

namespace BloonTowerMaker.Logic
{
    class SelectImage
    {
        public enum image_type
        {
            ICON,
            PORTRAIT,
            PROJECTILE,
            DISPLAY
        }
        public static image_type imageType;

        [Obsolete]
        public static Image GetImage(image_type img, string path)
        {
            var filename = Path.Combine(Project.instance.projectPath, Models.ParsePath(path));
            var files = Directory.GetFiles(filename,"*.png").ToList();
            try
            {
                switch (img)
                {
                    case image_type.ICON:
                        return new Bitmap(Image.FromFile(files.Find(x => x.Contains("Icon"))));
                    case image_type.PORTRAIT:
                        return new Bitmap(Image.FromFile(files.Find(x => x.Contains("Portrait"))));
                    case image_type.PROJECTILE:
                        return new Bitmap(Image.FromFile(files.Find(x => x.Contains("Projectile")))); 
                    case image_type.DISPLAY:
                        return new Bitmap(Image.FromFile(files.Find(x => x.Contains("Display"))));
                    default:
                        return null; //replace with blank image
                }
            } catch

            {
                return null;
            }
        }

        //Load Image from name (Resource folder)
        public static Image LoadImage(string name)
        {
            //Skip no image
            if (string.IsNullOrWhiteSpace(name)) return null;

            //Add missing .png
            if (!name.Contains(".png")) name += ".png";

            //Get image file path
            var imagePath = Path.Combine(Project.instance.projectPath, Resources.ProjectResourcesFolder,name);

            //Check if the image exist
            if (!File.Exists(imagePath)) throw new Exception($"Image {name} not found!");


            //Read image
            try
            {
                return Image.FromFile(imagePath);
            }
            catch
            {
                return null;
            }
        }

        public static void SaveImage(string path)
        {
            var fileName = Path.GetFileName(path);
            try
            {
                File.Copy(path, Path.Combine(Project.instance.projectPath, Resources.ProjectResourcesFolder, fileName));
            }
            catch
            {
                //throw new Exception("Cant copy image from path " + path);
            }
        }
    }
}
