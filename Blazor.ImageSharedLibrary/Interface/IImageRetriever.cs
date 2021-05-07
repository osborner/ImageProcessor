using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.ImageSharedLibrary.Interface
{
    public interface IImageRetriever
    {
        Task<Image> RetrieveImage(string path);
    }
}
