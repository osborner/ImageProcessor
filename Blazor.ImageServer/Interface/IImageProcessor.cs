using Blazor.ImageServer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageServer.Interface
{
    interface IImageProcessor
    {
        Task SubmitSelection(ImageSelection selection);
    }
}
