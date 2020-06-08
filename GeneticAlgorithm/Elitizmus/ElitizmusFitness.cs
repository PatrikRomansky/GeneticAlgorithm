using GeneticAlgorithm.Individuals;
using System.Collections.Generic;
using System.Linq;


namespace GeneticAlgorithm.Elitizmus
{
    public class ElitizmusFitness : IElitizmus
    {
        public double ElitePercentage { get; }

        public ElitizmusFitness(double elitePercentage = 0.1)
        {
            ElitePercentage = elitePercentage;
        }

        public IList<IIndividual> EliteIndividuals(int popSize, IList<IIndividual> offspring, IList<IIndividual> parents)
        {
            int eliteIndsCount = (int) (popSize * ElitePercentage);

            if (eliteIndsCount < 1)
                return offspring;

            var ordered = parents.OrderByDescending(c => c.Fitness).Take(eliteIndsCount).ToList();

            for (int i = 0; i < popSize - eliteIndsCount; i++)
            {
                ordered.Add(offspring[i]);
            }


            return ordered;
        }
    }
}
