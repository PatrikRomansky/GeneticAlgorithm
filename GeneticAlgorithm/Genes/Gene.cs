using System;

namespace GeneticAlgorithm.Genes
{
    public sealed class Gene
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public Object Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the gene.
        /// </summary>
        /// <param name="value">The gene initial value.</param>
        public Gene(object value)
        {
            this.Value = value;
        }
    }
}
