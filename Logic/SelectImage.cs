using BloonTowerMaker.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
