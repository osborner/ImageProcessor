using Blazor.ImageApi.Service;
using Blazor.ImageSharedLibrary.Interface;
using Moq;
using NUnit.Framework;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Blazor.ImageTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetImageDetails_ReturnsCorrectFilePathAndDimensions()
        {
            var dummyFileName = "test.png";
            var expectedFileLocation = $"https://localhost:44382/sample-data/{dummyFileName}";
            var dummyBmp = new Bitmap(5, 5);
            MemoryStream stream = new MemoryStream();
            dummyBmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            var dummyImage = Image.FromStream(stream);
            var imageAnalyser = new Mock<IImageAnalyser>();
            var imageRetriever = new Mock<IImageRetriever>();
            imageRetriever.Setup(ir => ir.RetrieveImage(It.IsAny<string>())).ReturnsAsync(dummyImage);
            var imageProcessor = new ImageProcessor(imageAnalyser.Object, imageRetriever.Object);

            var returnedDetails = await imageProcessor.GetImageDetails(dummyFileName);

            Assert.AreEqual(expectedFileLocation, returnedDetails.FileName);
            Assert.AreEqual(dummyImage.Width, returnedDetails.Width);
            Assert.AreEqual(dummyImage.Height, returnedDetails.Height);
        }
    }
}