using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Randomization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Operators.Xover
{
    class XoverOnePoint : Xover
    {

        /// <summary>
        /// Initializes a new instance of One point crossover.
        /// </summary>
        public XoverOnePoint()
        {
            ParentsNumber = 2;
            ChildrenNumber = 2;
            IsOrdered = true;
        }

        public override IList<IIndividual> Cross(IList<IIndividual> parents)
        {
            if (parents[0].Length != parents[1].Length)
                return parents;

            int swapPoint = RandomizationRnd.GetInt(1, parents[0].Length - 2);

            var firstChild = CreateChild(parents[0], parents[1], swapPoint);
            var secondChild = CreateChild(parents[1], parents[0], swapPoint);

            return new List<IIndividual>() { firstChild, secondChild };

        }

        /// <summary>
        /// Creates the child.
        /// </summary>
        /// <param name="leftParent">Left parent.</param>
        /// <param name="rightParent">Right parent</param>
        /// <param name="swapPoint">The index of the swap point.</param>
        /// <returns>The child.</returns>
        protected virtual IIndividual CreateChild(IIndividual leftParent, IIndividual rightParent, int swapPoint)
        {
            var cutGenesCount = swapPoint + 1;
            var child = leftParent.CreateNew();
            child.ReplaceGenes(0, leftParent.GetGenes().Take(cutGenesCount).ToArray());
            child.ReplaceGenes(cutGenesCount, rightParent.GetGenes().Skip(cutGenesCount).ToArray());

            return child;
        }
    }
}
