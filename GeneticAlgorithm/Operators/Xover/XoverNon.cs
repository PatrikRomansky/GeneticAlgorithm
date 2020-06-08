using GeneticAlgorithm.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Operators.Xover
{
    class XoverNon : Xover
    {
        /// <summary>
        /// Do nothing.
        /// </summary>
        public XoverNon()
        {

            ParentsNumber = 2;
            ChildrenNumber = 2;
            IsOrdered = true;
        }
        public override IList<IIndividual> Cross(IList<IIndividual> parents)
        {
            return parents;
        }
    }
}
