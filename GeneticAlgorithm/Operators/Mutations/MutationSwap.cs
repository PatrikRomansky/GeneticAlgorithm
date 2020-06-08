﻿using GeneticAlgorithm.Individuals;

namespace GeneticAlgorithm.Operators.Mutations
{
    public abstract class MutationSwap : Mutation
    {
        /// <summary>
        /// Swap two genes position.
        /// </summary>
        /// <param name="firstIndex">First gene</param>
        /// <param name="secondIndex">Second gene</param>
        /// <param name="individual">Ind</param>
        protected void SwapGenes(int firstIndex, int secondIndex, IIndividual individual)
        {
            var firstGene = individual.GetGene(firstIndex);
            var secondGene = individual.GetGene(secondIndex);

            individual.ReplaceGene(firstIndex, secondGene);
            individual.ReplaceGene(secondIndex, firstGene);
        }
    }
}
