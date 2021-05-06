using Blazor.ImageSharedLibrary.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.ImageSharedLibrary.Interface
{
    public interface IImageAnalyser
    {
        Task<AnalysisResult[]> Analyse(Bitmap image);
    }
}
