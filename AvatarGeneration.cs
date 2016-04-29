using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace DemoImageGeneration
{
    class Program
    {
        // --> Add reference system.drawing
        static void Main(string[] args)
        {
            GenerateAvatar("Archibald", "Haddock");
            GenerateAvatar("Tryphon", "Tournesol");
            
            Process.Start(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        }


        private static List<string> backgroundColours = new List<string> { "3C79B2", "FF8F88", "6FB9FF", "C0CC44", "AFB28C" };
        public static void GenerateAvatar(string firstName, string lastName)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(firstName), "firstName is required");
            Contract.Requires(!string.IsNullOrWhiteSpace(lastName), "lastName is required");
            string avatarString = string.Format("{0}{1}", firstName[0], lastName[0]).ToUpper();
            var randomIndex = new Random().Next(0, backgroundColours.Count - 1);
            var bgColour = backgroundColours[randomIndex];
            var bmp = new Bitmap(192, 192); // sustem.drawing dll
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", 48, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);

            graphics.Clear((Color)new ColorConverter().ConvertFromString("#" + bgColour));
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.DrawString(avatarString, font, new SolidBrush(Color.WhiteSmoke), new RectangleF(0, 0, 192, 192), sf);
            graphics.Flush();

            string filename = string.Format("{0}_{1}.png", firstName, lastName);
            bmp.Save(filename, ImageFormat.Png);

            Contract.Assert(File.Exists(filename), "File " + filename + " was not created");
        }

    }
}
