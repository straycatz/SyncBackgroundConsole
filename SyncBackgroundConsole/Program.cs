using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncBackgroundConsole
{
    class Program
    {
   
        static void Main(string[] args)
        {
            var assetsForder = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            var pictureForder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\Assets";

            if (!Directory.Exists(assetsForder)) return;
            if (!Directory.Exists(pictureForder)) Directory.CreateDirectory(pictureForder);

            var di = new System.IO.DirectoryInfo(assetsForder);
            var files = di.EnumerateFiles("*", System.IO.SearchOption.AllDirectories);

            foreach (System.IO.FileInfo f in files)
            {
                using (var img = new Bitmap(Image.FromFile(f.FullName)))
                {
                    if (img.Width == 1920)
                    {
                        var format = img.RawFormat;
                        var outputPath = pictureForder + @"\" + Path.GetFileName(f.FullName) + @".png";
                        if (!File.Exists(outputPath))
                        {
                            try
                            {
                                img.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            catch (Exception) { }
                        }
                    }
                }
            }
        }
    }
}
