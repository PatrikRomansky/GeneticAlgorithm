using GeneticAlgorithm.Genes;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Populations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Selections
{
    class SelectionNon : ISelection
    {
        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="number">Number of selected.</param>
        /// <param name="generation">Cur. generation</param>
        /// <returns>Selected individuals.</returns>
        public IList<IIndividual> SelectIndividuals(int number, IPopulation generation)
        {
            return generation.Individuals;
        }
    }
}
