using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Blazor.ImageSharedLibrary.Class;
using Blazor.ImageSharedLibrary.Interface;

namespace Blazor.ImageApi.Service
{
    public class ImageProcessor : IImageProcessor
    {
        const string ImageDirectory = "sample-data";
        private readonly IImageAnalyser _imageAnalyser;

        public ImageProcessor(IImageAnalyser imageAnalyser)
        {
            _imageAnalyser = imageAnalyser;
        }
        public async Task<ReturnImageDetails> GetImageDetails(string fileName)
        {
            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var fileLocation = Path.Combine("https://localhost:44382/sample-data/", fileName);
            Image image;
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(new Uri(fileLocation));
                image = Image.FromStream(stream);
                if (image == null)
                    throw new FileNotFoundException("Image not found.");
            }

            stopwatch.Stop();
            return new ReturnImageDetails
            {
                FileName = fileLocation,
                Width = image.Width,
                Height = image.Height,
                TimeToProcess = stopwatch.Elapsed
            };
        }

        public async Task<AnalysisResult[]> SubmitSelection(ImageSelection selection)
        {
            // Proof of concept - receives selection and extracts section of base image.
            Image image;
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(new Uri(selection.BaseImagePath));
                image = Image.FromStream(stream);
                if (image == null)
                    throw new FileNotFoundException("Image not found.");
            }
            Bitmap baseBmp = new Bitmap(image);
            RectangleF cropRegion = new RectangleF((float)selection.X, (float)selection.Y, (float)selection.Width, (float)selection.Height);
            var outputBitmap = new Bitmap((int)selection.Width, (int)selection.Height);
            Graphics selectedArea = Graphics.FromImage(outputBitmap);
            selectedArea.DrawImage(baseBmp, 0, 0, cropRegion, GraphicsUnit.Pixel);

            // Result of DrawImage can be used in further processing/analysis
            return await _imageAnalyser.Analyse(outputBitmap);
        }
    }
}
