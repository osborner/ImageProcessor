using Blazor.ImageClient.Interface;
using Blazor.ImageSharedLibrary.Class;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.ImageClient.Service
{
    public class ImageService : IImageService
    {
        private HttpClient httpClient { get; }
        public ImageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ReturnImageDetails> GetImageDetails(string filename)
        {
            return await httpClient.GetFromJsonAsync<ReturnImageDetails>($"api/imageservice?imagename={filename}");
        }

        public async Task<AnalysisResult[]> SubmitSelection(ImageSelection selection)
        {
            var response = await httpClient.PostAsJsonAsync($"api/imageservice", selection);
            return await response.Content.ReadFromJsonAsync<AnalysisResult[]>();
        }
    }
}
