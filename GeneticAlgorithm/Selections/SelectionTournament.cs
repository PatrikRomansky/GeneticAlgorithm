using GeneticAlgorithm.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Randomization;
using GeneticAlgorithm.Populations;

namespace GeneticAlgorithm.Selections
{
    class SelectionTournament : ISelection
    {
        /// <summary>
        /// Selects the number of individuals from the generation.
        /// Tournament selection.
        /// </summary>
        /// <param name="number">Number of selected.</param>
        /// <param name="generation">Cur. generation</param>
        /// <returns>Selected individuals.</returns>
        public IList<IIndividual> SelectIndividuals(int number, IPopulation generation)
        {
            var candidates = generation.Individuals.ToList();
            var selected = new List<IIndividual>();

            while (selected.Count < number)
            {
                var randomIndexes = RandomizationRnd.GetUniqueInts(2, 0, candidates.Count);
                var tournamentWinner = candidates.Where((c, i) => randomIndexes.Contains(i)).OrderByDescending(c => c.Fitness).First();

                selected.Add(tournamentWinner);

            }

            return selected;
        }
    }
}
