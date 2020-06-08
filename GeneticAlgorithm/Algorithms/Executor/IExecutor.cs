using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Populations;
using GeneticAlgorithm.Xover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Executor
{
    public interface IExecutor
    {   
        /// <summary>
        /// Fitness executor.
        /// </summary>
        /// <param name="fitness">Fitness func.</param>
        /// <param name="population">Input population</param>
        void EvaluateFitness(IFitness fitness, IPopulation population);

        /// <summary>
        /// Mutation executor.
        /// </summary>
        /// <param name="mutation">Mutation func.</param>
        /// <param name="mutationProbability">Mutation probability</param>
        /// <param name="individuals">Individual</param>
        void Mutate(IMutation mutation, float mutationProbability, IList<IIndividual> individuals);

        /// <summary>
        /// Crossover executor.
        /// </summary>
        /// <param name="population">Input population.</param>
        /// <param name="xover">Crossover func.</param>
        /// <param name="xoverProbability">Crossver probability</param>
        /// <param name="parents">Parents list</param>
        /// <returns>Childten(individuals)</returns>
        IList<IIndividual> Cross(IPopulation population, IXover xover, float xoverProbability, IList<IIndividual> parents);
    }
}
