﻿using System.Linq;
using System.Collections.Generic;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Populations;

namespace GeneticAlgorithm.Selections
{
    public class SelectionElite : ISelection
    {
        /// <summary>
        /// Selects the number of individuals from the generation.
        /// First n.
        /// </summary>
        /// <param name="number">Number of selected.</param>
        /// <param name="generation">Cur. generation</param>
        /// <returns>Selected individuals.</returns>
        public IList<IIndividual> SelectIndividuals(int number, IPopulation generation)
        {
            var orderedIndividuals = generation.Individuals.OrderByDescending(c => c.Fitness);

            return orderedIndividuals.Take(number).ToList();
        }
    }
}
