﻿using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Populations;
using GeneticAlgorithm.Randomization;
using GeneticAlgorithm.Xover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Executor
{
    public class ExecutorLinear : IExecutor
    {
        /// <summary>
        /// Linear fitness evaluation.
        /// </summary>
        /// <param name="fitness">Fitness func.</param>
        /// <param name="population">Input Population</param>
        public virtual void EvaluateFitness(IFitness fitness, IPopulation population)
        {
            foreach (var ind in population.Individuals)
            {
                // non-fitness value
                if (!ind.Fitness.HasValue)
                {
                    ind.Fitness = fitness.Evaluate(ind);
                }
            }

            population.Individuals = population.Individuals.OrderByDescending(c => c.Fitness.Value).ToList();
        }

        /// <summary>
        /// Linear mutaion execution.
        /// </summary>
        /// <param name="mutation">Mutation func.</param>
        /// <param name="mutationProbability">Probability of mutaiton</param>
        /// <param name="individuals">Individual</param>
        public virtual void Mutate(IMutation mutation, float mutationProbability, IList<IIndividual> individuals)
        {
            for (int i = 0; i < individuals.Count; i++)
            {
                mutation.Mutate(individuals[i], mutationProbability);
            }
        }

        /// <summary>
        /// Linear crossover executor.
        /// </summary>
        /// <param name="population">Input population.</param>
        /// <param name="xover">Crossover func.</param>
        /// <param name="xoverProbability">Crossver probability</param>
        /// <param name="parents">Parents list</param>
        /// <returns>Childten(individuals)</returns>
        public virtual IList<IIndividual> Cross(IPopulation population, IXover xover, float xoverProbability, IList<IIndividual> parents)
        {
            var size = population.Size;

            var offspring = new List<IIndividual>(size);

            for (int i = 0; i < size; i += xover.ChildrenNumber)
            {
                var selectedParents = parents.Skip(i).Take(xover.ParentsNumber).ToList();

                // If match the probability cross is made, otherwise the offspring is an exact copy of the parents.
                // Checks if the number of selected parents is equal which the crossover expect, because the in the end of the list we can
                // have some rest chromosomes.
                if (selectedParents.Count == xover.ParentsNumber && RandomizationRnd.GetDouble() <= xoverProbability)
                {
                    offspring.AddRange(xover.Cross(selectedParents));
                }
                else
                {
                    offspring.AddRange(selectedParents);
                }
            }

            return offspring;

        }

    }
}
