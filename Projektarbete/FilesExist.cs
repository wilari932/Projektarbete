using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Projektarbete
{
    class FilesExist
    {
        public enum Filetype {Folder, Txt, Picture}
        public Filetype GetFiletype { get; set; }

        public void FilesExistt( string path, Filetype filetype)
        {
            if(filetype == Filetype.Folder)
            {
                if (!Directory.Exists(@path))
                {
                    Directory.CreateDirectory(@path);
                }
          
            }
            else if (filetype == Filetype.Txt)
            {
                if (!File.Exists(@path))
                {
                    File.CreateText(@path);
                }
            }

            else if (filetype == Filetype.Picture)
            {
                if (!File.Exists(path))
                {
                    Bitmap bmp = new Bitmap(20, 20);
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(Brushes.Green, 0, 0, 50, 50);
                    g.Dispose();
                    bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                    bmp.Dispose();
                }
            }

        }

    }
}
