using Blazor.ImageSharedLibrary.Class;
using Blazor.ImageSharedLibrary.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blazor.ImageApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageServiceController : ControllerBase
    {
        private readonly ILogger<ImageServiceController> _logger;
        private readonly IImageProcessor _processor;

        public ImageServiceController(ILogger<ImageServiceController> logger, IImageProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [HttpGet]
        public async Task<ReturnImageDetails> Get(string imageName)
        {
            return await _processor.GetImageDetails(imageName);
        }

        [HttpPost]
        public async Task<AnalysisResult[]> Post(ImageSelection selection)
        {
            return await _processor.SubmitSelection(selection);            
        }
    }
}
