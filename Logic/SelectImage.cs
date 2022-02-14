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
            PROJECTILE
        }
        public static image_type imageType;

        public static Image GetImage(image_type img, string path)
        {
            var filename = Models.getImagesPath(path);
            try
            {
                switch (img)
                {
                    case image_type.ICON:
                        return new Bitmap(Image.FromFile(filename + "icon.png"));
                    case image_type.PORTRAIT:
                        return new Bitmap(Image.FromFile(filename + "portrait.png"));
                    case image_type.PROJECTILE:
                        return new Bitmap(Image.FromFile(filename + "projectile.png"));
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
