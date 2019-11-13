using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace EXIFAdd
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 control = new Form1();
            // control.ShowDialog();
            // Excel ExcelFile = new Excel(control.ExcelFile);
            Bitmap newImage = new Bitmap("C:\\Users\\Stephen\\Desktop\\test.jpg");
                
                //Image.FromFile("C:\\Users\\Stephen\\Desktop\\test.jpg");
            // Images.ImageMetadata imageMetadata = new Images.ImageMetadata("Title12", "Author12", "test12", "test12");
            //  Images.clsReadMetaData MDS = new Images.clsReadMetaData();
            // Images.ImageMetadata imageMetadataorig = MDS.ReadEXIFMetadata("C:\\Users\\Stephen\\Desktop\\test.jpg");
            // imageMetadataorig.Title = "New Title\0";
            // MDS.SaveEXIFMetadata(newImage, imageMetadataorig, "C:\\Users\\Stephen\\Desktop\\test2.jpg");
            // Images.ImageMetadata imageMetadataorig2 = MDS.ReadEXIFMetadata("C:\\Users\\Stephen\\Desktop\\test.jpg");

            // Images2.MetaProperty.Title;
            Bitmap newImagefix = Images2.SetMetaValue(newImage, Images2.MetaProperty.Title, "Title Test");
            Bitmap newImagefix2 = Images2.SetMetaValue(newImagefix, Images2.MetaProperty.Author, "Title Test");
            Bitmap newImagefix3 = Images2.SetMetaValue(newImagefix2, Images2.MetaProperty.Subject, "Title Test");
            newImagefix3.Save("C:\\Users\\Stephen\\Desktop\\test3.jpg", ImageFormat.Jpeg);
        }
    }
}
