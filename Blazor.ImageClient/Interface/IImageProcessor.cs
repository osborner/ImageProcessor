using Blazor.ImageClient.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageClient.Interface
{
    interface IImageProcessor
    {
        Task SubmitSelection(ImageSelection selection);
    }
}
