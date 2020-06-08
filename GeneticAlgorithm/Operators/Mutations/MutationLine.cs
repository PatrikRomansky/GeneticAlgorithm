using GeneticAlgorithm.Genes;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Randomization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Security.Cryptography;
using Emgu.CV.Flann;

namespace GeneticAlgorithm.Operators.Mutations
{
    class MutationLine : Mutation
    {
        // max line/shift
        int shift;

        public MutationLine()
        {
            this.shift = 5;
        }


        /// <summary>
        /// Mutate the specified individual.
        /// Shifted line
        /// </summary>
        /// <param name="individual">The individual.</param>
        /// <param name="mutation_probabilty">The probability to mutate each indiviudal.</param>
        public override void Mutate(IIndividual individual, float mutation_probabilty)
        {

            var indexes = RandomizationRnd.GetInts(1, 0, individual.Length);
            foreach (var index in indexes)
            {
                var oldGene = individual.GetGene(index);

                var shift1 = RandomizationRnd.GetInt(-shift, shift);
                var shift2 = RandomizationRnd.GetInt(-shift, shift);
                var shift3 = RandomizationRnd.GetInt(-shift, shift);
                var shift4 = RandomizationRnd.GetInt(-shift, shift);

                LineSegment2D line = (LineSegment2D)oldGene.Value;

                var p1 = new Point(line.P1.X + shift1, line.P1.Y + shift2);
                var p2 = new Point(line.P2.X + shift3, line.P2.Y + shift4);

                individual.ReplaceGene(index, new Gene(new LineSegment2D(p1, p2)));
            }
                    
        }
    }
}
