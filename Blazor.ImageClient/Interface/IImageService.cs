using Blazor.ImageSharedLibrary.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageClient.Interface
{
    public interface IImageService
    {
        Task<ReturnImageDetails> GetImageDetails(string filename);
        Task<ReturnImageDetails> SubmitSelection(ImageSelection selection);
    }
}
