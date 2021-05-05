using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.ImageSharedLibrary.Class
{
    public class ReturnImageDetails
    {
        public string FileName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public TimeSpan TimeToProcess { get; set; }
    }
}
