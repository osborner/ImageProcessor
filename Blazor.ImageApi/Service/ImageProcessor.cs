using Blazor.ImageSharedLibrary.Class;
using Blazor.ImageSharedLibrary.Interface;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Blazor.ImageApi.Service
{
    public class ImageProcessor : IImageProcessor
    {
        const string ImageDirectory = "sample-data/";
        const string baseUrl = "https://localhost:44382/";
        private readonly IImageAnalyser _imageAnalyser;
        private readonly IImageRetriever _imageRetriever;

        public ImageProcessor(IImageAnalyser imageAnalyser, IImageRetriever imageRetriever)
        {
            _imageAnalyser = imageAnalyser;
            _imageRetriever = imageRetriever;
        }
        public async Task<ReturnImageDetails> GetImageDetails(string fileName)
        {
            // Hardcoded URL as an example, change this in the real world
            var fileLocation = Path.Combine(baseUrl, ImageDirectory, fileName);
            var image = await _imageRetriever.RetrieveImage(fileLocation);

            return new ReturnImageDetails
            {
                FileName = fileLocation,
                Width = image.Width,
                Height = image.Height
            };
        }

        public async Task<AnalysisResult[]> SubmitSelection(ImageSelection selection)
        {
            // Proof of concept - receives selection and extracts section of base image.
            var image = await _imageRetriever.RetrieveImage(selection.BaseImagePath);
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
