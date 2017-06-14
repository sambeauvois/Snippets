using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTestSSS
{
    class Program
    {
        static void Main(string[] args)
        {
            // prepare a list of images
            string[] files = Directory.GetFiles("Pics");
            List<Image> imgs = new List<Image>();
            foreach (string file in files)
            {
                imgs.Add(Bitmap.FromFile(file));
            }

            // define the height as the sum of all images height
            int outputHeight = imgs.Sum(x => x.Height);
            // define the width as the largest one
            int outputWidth = imgs.Max(x => x.Width);
            Bitmap outputImage = new Bitmap(outputWidth, outputHeight);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                int y=0; // what you missed is the y point, start at zero then add the height of the drawed image
                foreach(Image img in imgs)
                {
                    graphics.DrawImage(img, new Rectangle(new Point(0,y), img.Size), 
                        new Rectangle(new Point(), img.Size), GraphicsUnit.Pixel);

                    y += img.Height;
                }
               
            }

            outputImage.Save("Pics/output.bmp");


            Console.WriteLine("f");
            Console.ReadLine();





        }
    }
}
