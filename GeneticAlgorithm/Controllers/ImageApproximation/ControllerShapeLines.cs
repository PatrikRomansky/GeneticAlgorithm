using Emgu.CV;
using Emgu.CV.Structure;
using GeneticAlgorithm.Elitizmus;
using GeneticAlgorithm.Executor;
using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Operators.Mutations;
using GeneticAlgorithm.Operators.Xover;
using GeneticAlgorithm.Selections;
using GeneticAlgorithm.Terminations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Controllers.ImageApproximation
{

    class ControllerShapeLines : ControllerImage
    {
        int numberOfLine;
        public override IIndividual CreateIndividual()
        {
            return new IndividualShapeLine(width, height, numberOfLine) ;
        }

        public override void Initialize(object target)
        {
            var inputImageFile = (String)target;

            mutation = new MutationLineAdaptive();
            xover = new XoverUniform();
            selection = new SelectionTournament();
            elitizmus = new ElitizmusFitness(0.1);
            termination = new TerminationMaxGenerationNumber(150_000);

            executor = new ExecutorParallel();

            // var targetBitmap = Bitmap.FromFile(inputImageFile) as Bitmap;

            var targetImg = new Image<Gray, Byte>(inputImageFile);

            var fit = new FitnessLine(targetImg);
            width = fit.Width;
            height = fit.Height;
            numberOfLine = fit.targetBitmapLineCount;


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
                var best = bestIndividual as IndividualShapeLine;

                using (var bitmap = best.BuildBitmap())
                {
                    var fileName = m_destFolder + "/" + GA.GenerationsNumber.ToString("D10") + "_" + best.Fitness + ".png";
                    bitmap.Save(fileName);
                    return fileName;
                }
            }
            return null;
        }
    }
}
