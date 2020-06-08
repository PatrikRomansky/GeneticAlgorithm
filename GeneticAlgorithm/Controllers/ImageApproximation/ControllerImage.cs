using System;
using System.IO;

using ImageMagick;

using GeneticAlgorithm.Algorithms;
using GeneticAlgorithm.Elitizmus;
using GeneticAlgorithm.Executor;
using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Selections;
using GeneticAlgorithm.Terminations;
using GeneticAlgorithm.Xover;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GeneticAlgorithm.Controllers.ImageApproximation
{
    public abstract class ControllerImage : IController
    {
        protected int width, height;

        protected IXover xover;
        protected IFitness fitness;
        protected IMutation mutation;
        protected ISelection selection;
        protected IElitizmus elitizmus;
        protected ITermination termination;
        protected IExecutor executor;

        protected string m_destFolder;

        protected GA GA { get; set; }

        public virtual void ConfigGA(GA ga)
        {
            GA = ga;
            ga.MutationProbability = 0.7f;
            ga.TerminationReached += (sender, args) =>
            {
                using (var collection = new MagickImageCollection())
                {
                    var files = Directory.GetFiles(m_destFolder, "*.png");

                    foreach (var image in files)
                    {
                        collection.Add(image);
                        collection[0].AnimationDelay = 100;
                    }

                    var settings = new QuantizeSettings();
                    settings.Colors = 256;
                    collection.Quantize(settings);

                    collection.Optimize();
                    collection.Write(Path.Combine(m_destFolder, "result.gif"));
                }
            };
        }

        public virtual IXover CreateCrossover()
        {
            return xover;
        }

        public virtual IFitness CreateFitness()
        {
            return fitness;
        }

        public virtual IMutation CreateMutation()
        {
            return mutation;
        }

        public virtual ISelection CreateSelection()
        {
            return selection;
        }
        public IElitizmus CreateElitizmus()
        {
            return elitizmus;
        }

        public virtual ITermination CreateTermination()
        {
            return termination;
        }

        public IExecutor CreateExecutor()
        {
            return executor;
        }

        public abstract void Initialize(Object target);

        public abstract Object ShowBestIndividual(IIndividual bestIndividual);

        public abstract IIndividual CreateIndividual();
    }
}
