using Blazor.ImageClient.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageClient.Class
{
    public class ImageProcessor : IImageProcessor
    {
        public async Task SubmitSelection(ImageSelection selection)
        {
            Bitmap image = new Bitmap(selection.BaseImagePath);
            RectangleF croppedOutput = new RectangleF((float)selection.X, (float)selection.Y, (float)selection.Width, (float)selection.Height);
            var outputBitmap = new Bitmap((int)selection.Width, (int)selection.Height);
            Graphics g = Graphics.FromImage(outputBitmap);
            g.DrawImage(image, 0, 0, croppedOutput, GraphicsUnit.Pixel);
            outputBitmap.Save($"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}", ImageFormat.Png);
            return;
        }
    }
}
