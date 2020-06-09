using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Randomization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Operators.Xover
{
    class XoverTwoPoints : Xover
    {
        int minParentSize;

        public XoverTwoPoints()
        {
            ParentsNumber = 2;
            ChildrenNumber = 2;
            IsOrdered = true;
            minParentSize = 3;
        }

        public override IList<IIndividual> Cross(IList<IIndividual> parents)
        {
            // This xover need same length
            if (parents[0].Length != parents[1].Length | parents[0].Length <= minParentSize)
                return parents;



            var swapPoints = RandomizationRnd.GetUniqueInts(2, 1, parents[0].Length - 2);
            int firstIndex = swapPoints[0];
            int secondIndex = swapPoints[1];

            if (secondIndex < firstIndex)
            {
                secondIndex = swapPoints[0];
                firstIndex = swapPoints[1];
            }

            var firstChild = CreateChild(parents[0], parents[1], firstIndex, secondIndex);
            var secondChild = CreateChild(parents[1], parents[0], firstIndex, secondIndex);

            return new List<IIndividual>() { firstChild, secondChild };
        }

        /// <summary>
        /// Creates the child.
        /// </summary>
        /// <param name="leftParent">Left parent.</param>
        /// <param name="rightParent">Right parent</param>
        /// <param name="firstSwapPoint">he index of the swap point one gene.</param>
        /// <param name="secondSwapPoint">he index of the swap point two gene.</param>
        /// <returns>The child.</returns>
        protected IIndividual CreateChild(IIndividual leftParent, IIndividual rightParent, int firstSwapPoint, int secondSwapPoint)
        {
            var firstCutGenesCount = firstSwapPoint + 1;
            var secondCutGenesCount = secondSwapPoint + 1;
            var child = leftParent.CreateNew();
            child.ReplaceGenes(0, leftParent.GetGenes().Take(firstCutGenesCount).ToArray());
            child.ReplaceGenes(firstCutGenesCount, rightParent.GetGenes().Skip(firstCutGenesCount).Take(secondCutGenesCount - firstCutGenesCount).ToArray());
            child.ReplaceGenes(secondCutGenesCount, leftParent.GetGenes().Skip(secondCutGenesCount).ToArray());

            return child;
        }
    }
}
