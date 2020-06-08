using System;
using System.IO;
using System.Drawing;
using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Terminations;
using GeneticAlgorithm.Operators.Mutations;
using GeneticAlgorithm.Operators.Xover;
using GeneticAlgorithm.Selections;
using GeneticAlgorithm.Algorithms;
using GeneticAlgorithm.Elitizmus;
using GeneticAlgorithm.Executor;


namespace GeneticAlgorithm.Controllers.ImageApproximation
{
    public class ControllerBitmap : ControllerImage
    {

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

            var targetBitmap = Bitmap.FromFile(inputImageFile) as Bitmap;


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
    }
}

