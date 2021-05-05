using Blazor.ImageSharedLibrary.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageSharedLibrary.Interface
{
    public interface IImageProcessor
    {
        Task<ReturnImageDetails> SubmitSelection(ImageSelection selection);
        Task<ReturnImageDetails> GetImagePath(string fileName);
    }
}
