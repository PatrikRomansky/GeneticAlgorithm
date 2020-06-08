using System;

using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Xover;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Selections;
using GeneticAlgorithm.Terminations;
using GeneticAlgorithm.Algorithms;
using GeneticAlgorithm.Elitizmus;
using GeneticAlgorithm.Executor;

namespace GeneticAlgorithm.Controllers
{
    public interface IController
    {

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize(Object target);

        /// <summary>
        /// Configure the Genetic Algorithm.
        /// </summary>
        /// <param name="ga">The genetic algorithm.</param>
        void ConfigGA(GA ga);

        /// <summary>
        /// Creates the chromosome.
        /// </summary>
        /// <returns>The chromosome.</returns>
        IIndividual CreateIndividual();

        /// <summary>
        /// Draws the sample.
        /// </summary>
        /// <param name="bestIndividual">The current best chromosome</param>
        Object ShowBestIndividual(IIndividual bestIndividual);

        /// <summary>
        /// Creates the fitness.
        /// </summary>
        /// <returns>The fitness.</returns>
        IFitness CreateFitness();

        /// <summary>
        /// Creates the termination.
        /// </summary>
        /// <returns>The termination.</returns>
        ITermination CreateTermination();

        /// <summary>
        /// Creates the crossover.
        /// </summary>
        /// <returns>The crossover.</returns>
        IXover CreateCrossover();

        /// <summary>
        /// Creates the mutation.
        /// </summary>
        /// <returns>The mutation.</returns>
        IMutation CreateMutation();

        /// <summary>
        /// Creates the selection.
        /// </summary>
        /// <returns>The selection.</returns>
        ISelection CreateSelection();

        /// <summary>
        /// Creates the elitizmus.
        /// </summary>
        /// <returns>The elitizmus</returns>
        IElitizmus CreateElitizmus();

        /// <summary>
        /// Create executor.
        /// </summary>
        /// <returns>The executor,</returns>
        IExecutor CreateExecutor();
    }
}
