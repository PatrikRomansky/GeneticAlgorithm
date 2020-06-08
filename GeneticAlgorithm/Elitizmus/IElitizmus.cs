using System;
using System.Collections.Generic;
using GeneticAlgorithm.Individuals;

namespace GeneticAlgorithm.Elitizmus
{

    public interface IElitizmus
    {
        /// <summary>
        /// alive parents
        /// </summary>
        double ElitePercentage { get; }

        /// <summary>
        /// Reinsert the number of individuals from the generation.
        /// </summary>
        /// <param name="popSize">Population size</param>
        /// <param name="offspring">CNew individuals</param>
        /// <param name="parents">Parents</param>
        /// <returns> Elit population</returns>
        IList<IIndividual> EliteIndividuals(int popSize, IList<IIndividual> offspring, IList<IIndividual> parents);
    }
}
