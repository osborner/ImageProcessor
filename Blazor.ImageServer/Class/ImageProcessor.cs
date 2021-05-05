using Blazor.ImageServer.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Blazor.ImageServer.Class
{
    public class ImageProcessor : IImageProcessor
    {
        public async Task SubmitSelection(ImageSelection selection)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var directory = Path.GetDirectoryName(assembly.Location);
            var filePath = Path.Combine(directory, selection.BaseImagePath);
            var image = Image.FromFile(filePath);
            Bitmap baseBmp = new Bitmap(image);
            RectangleF cropRegion = new RectangleF((float)selection.X, (float)selection.Y, (float)selection.Width, (float)selection.Height);
            var outputBitmap = new Bitmap((int)selection.Width, (int)selection.Height);
            Graphics g = Graphics.FromImage(outputBitmap);
            g.DrawImage(baseBmp, 0, 0, cropRegion, GraphicsUnit.Pixel);
            outputBitmap.Save(Path.Combine(directory, $"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ff")}.png"), ImageFormat.Png);
            return;
        }
    }
}
