using Blazor.ImageSharedLibrary.Class;
using Blazor.ImageSharedLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageApi.Service
{
    public class ImageAnalyser : IImageAnalyser
    {
        public async Task<AnalysisResult[]> Analyse(Bitmap image)
        {
            var rng = new Random();
            var result = new AnalysisResult[]{
                new AnalysisResult {
                    X = rng.Next(0, image.Width),
                    Y = rng.Next(0, image.Height),
                    Message = "Text from analysis result 1"
                },
                new AnalysisResult {
                    X = rng.Next(0, image.Width),
                    Y = rng.Next(0, image.Height),
                    Message = "Text from analysis result 2"
                },
                new AnalysisResult {
                    X = rng.Next(0, image.Width),
                    Y = rng.Next(0, image.Height),
                    Message = "Text from analysis result 3"
                }
            };
            return result;
        }
    }
}
