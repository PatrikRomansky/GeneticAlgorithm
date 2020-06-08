using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Xover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Operators.Xover
{
    public abstract class Xover : IXover
    {
        public bool IsOrdered { get; protected set; }
        public int ParentsNumber{ get; protected set; }
        public int ChildrenNumber { get; protected set; }
        public abstract IList<IIndividual> Cross(IList<IIndividual> parents);
    }
}
