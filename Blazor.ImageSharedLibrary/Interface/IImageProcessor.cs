using Blazor.ImageSharedLibrary.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageSharedLibrary.Interface
{
    public interface IImageProcessor
    {
        Task<AnalysisResult[]> SubmitSelection(ImageSelection selection);
        Task<ReturnImageDetails> GetImageDetails(string fileName);
    }
}
