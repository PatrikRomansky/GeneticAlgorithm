using GeneticAlgorithm.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Elitizmus
{
    class ElitizmusNon : IElitizmus
    {
        public double ElitePercentage { get; }

        public ElitizmusNon(double elitePercentage = 0)
        {
            ElitePercentage = elitePercentage;
        }

        public IList<IIndividual> EliteIndividuals(int popSize, IList<IIndividual> offspring, IList<IIndividual> parents)
        {
            return offspring;
        }
    }
}
