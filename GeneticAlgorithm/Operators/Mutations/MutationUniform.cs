using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Randomization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Operators.Mutations
{
    class MutationUniform : Mutation
    {
        /// <summary>
        /// Initializes a new instance of uniform mutation.
        /// </summary>
        public MutationUniform()
        {
            IsOrdered = true;
        }

        public override void Mutate(IIndividual individual, float mutation_probabilty)
        {
            for (int index = 0; index < individual.Length; index++)
            {         
                if (RandomizationRnd.GetDouble() <= mutation_probabilty)
                {
                    individual.ReplaceGene(index, individual.GenerateGene());
                }
            }
        }
    }
}
