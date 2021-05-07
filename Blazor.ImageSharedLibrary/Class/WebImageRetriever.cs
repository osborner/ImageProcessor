using Blazor.ImageSharedLibrary.Interface;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Blazor.ImageSharedLibrary.Class
{
    public class WebImageRetriever : IImageRetriever
    {
        public async Task<Image> RetrieveImage(string path)
        {
            Image image;
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(new Uri(path));
                image = Image.FromStream(stream);
                if (image == null)
                    throw new FileNotFoundException("Image not found.");
            }
            return image;
        }
    }
}
