using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Operators.Mutations;
using GeneticAlgorithm.Operators.Xover;
using GeneticAlgorithm.Selections;
using GeneticAlgorithm.Elitizmus;
using GeneticAlgorithm.Terminations;
using GeneticAlgorithm.Executor;
using GeneticAlgorithm.Fitnesses;
using System.IO;

namespace GeneticAlgorithm.Controllers.ImageApproximation
{
    class ControllerBitmapScale : ControllerImage
    {
        private Bitmap targetBitmap;


        public override IIndividual CreateIndividual()
        {
            return new IndividualBitmap(width, height);
        }

        public override void Initialize(Object target)
        {

            var inputImageFile = (String)target;

            mutation = new MutationTwors();
            xover = new XoverUniform();
            selection = new SelectionTournament();
            elitizmus = new ElitizmusFitness();
            termination = new TerminationMaxGenerationNumber(30_000);

            executor = new ExecutorParallel();

            var img = ScaleImage(Image.FromFile(inputImageFile), 25);
            var targetBitmap = img as Bitmap;

            var fit = new FitnessBitmap(targetBitmap);
            width = fit.Width;
            height = fit.Height;
            fitness = fit;

            var folder = Path.Combine(Path.GetDirectoryName(inputImageFile), "results");
            var filePath = inputImageFile.Split('/');
            var fileName = filePath[filePath.Length - 1].Split('.')[0];
            m_destFolder = folder + "_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            Directory.CreateDirectory(m_destFolder);
        }

        public override Object ShowBestIndividual(IIndividual bestIndividual)
        {
            if (GA.GenerationsNumber % 100 == 0 | GA.GenerationsNumber == 1)
            {
                var best = bestIndividual as IndividualBitmap;

                using (var bitmap = best.BuildBitmap())
                {
                    var fileName = m_destFolder + "/" + GA.GenerationsNumber.ToString("D10") + "_" + best.Fitness + ".png";
                    bitmap.Save(fileName);
                    return fileName;
                }
            }

            return null;
        }

        public virtual Image ScaleImage(Image image, double percentage)
        {
            int width = (int)((percentage / 100.0) * image.Width);
            int height = (int)((percentage / 100.0) * image.Height);

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
