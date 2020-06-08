using System;
using System.IO;

using GeneticAlgorithm.Algorithms;
using GeneticAlgorithm.Controllers.ImageApproximation;
using GeneticAlgorithm.Populations;


using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Randomization;
using System.Drawing;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            Run();
        }

        private static void Run()
        {
            Console.SetError(TextWriter.Null);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GeneticSharp - ImageApproximation");
            Console.ResetColor();


            var sampleController = new ControllerBitmap();

            var input = "C:/Users/Tigi/Desktop/Source/kika2.jpg";

            sampleController.Initialize(input);

            Console.WriteLine("Starting...");

            var selection = sampleController.CreateSelection();
            var crossover = sampleController.CreateCrossover();
            var mutation = sampleController.CreateMutation();
            var fitness = sampleController.CreateFitness();
            var elitizmus = sampleController.CreateElitizmus();
            var executor = sampleController.CreateExecutor();
            var population = new Population(20, sampleController.CreateIndividual);




            var ga = new GA(population, fitness, selection, crossover, mutation, elitizmus, executor);
            ga.Termination = sampleController.CreateTermination();

            var terminationName = ga.Termination.GetType().Name;

            ga.GenerationInfo += delegate
            {
                Console.WriteLine("GeneticSharp - ConsoleApp");
                var bestIndividual = ga.Population.BestIndividual;
                Console.WriteLine("Termination: {0}", terminationName);
                Console.WriteLine("Generations: {0}", ga.Population.CurrentGenerationNumber);
                Console.WriteLine("Fitness: {0,10}", bestIndividual.Fitness);
                Console.WriteLine("Time: {0}", ga.TimeEvolving);
                Console.WriteLine("Speed (gen/sec): {0:0.0000}",  ga.TimeEvolving.TotalSeconds / ga.Population.CurrentGenerationNumber);
                sampleController.ShowBestIndividual(bestIndividual);
            };


            sampleController.ConfigGA(ga);
            ga.Run();  

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("Evolved.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
