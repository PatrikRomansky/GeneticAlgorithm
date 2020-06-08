using GeneticAlgorithm.Individuals;
using System;
using System.Collections.Generic;
using GeneticAlgorithm.Randomization;


namespace GeneticAlgorithm.Operators.Xover
{
    /// <summary>
    /// Uniform crossover operator.
    /// </summary>
    public class XoverUniform : Xover
    {
        private float mixProbability;
        public XoverUniform(float mixProbability = 0.5f)
        {
            this.mixProbability = mixProbability;
            ParentsNumber = 2;
            ChildrenNumber = 2;
            IsOrdered = true;
        }

        /// <summary>
        ///  Cross the specified parents generating the children.
        /// </summary>
        /// <param name="firstParent"> First parent</param>
        /// <param name="secondParent">Second parent</param>
        /// <returns>The offspring (children) of the parents.</returns>
        private IList<IIndividual> PerfomCross(IIndividual firstParent, IIndividual secondParent)
        {

           var firstChild = firstParent.CreateNew();
            var secondChild = firstParent.CreateNew();

            for (int i = 0; i < firstParent.Length; i++)
            {
                if (RandomizationRnd.GetDouble() < mixProbability)
                {
                    firstChild.ReplaceGene(i, firstParent.GetGene(i));
                    secondChild.ReplaceGene(i, secondParent.GetGene(i));
                }
                else
                {
                    firstChild.ReplaceGene(i, secondParent.GetGene(i));
                    secondChild.ReplaceGene(i, firstParent.GetGene(i));
                }
            }
            return new List<IIndividual> { firstChild, secondChild };
        }

        public override IList<IIndividual> Cross(IList<IIndividual> parents)
        {

            if (parents[0].Length < parents[1].Length)
            {
               return PerfomCross(parents[0],parents[1]);
            }
            else
            {
                return PerfomCross(parents[1], parents[0]);
            }
        }
    }
}
