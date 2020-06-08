﻿namespace GeneticAlgorithm.Operators
{
    public interface IOperator
    {
        /// <summary>
        /// Gets a value indicating whether the operator is ordered (if can keep the individual order).
        /// </summary>
        bool IsOrdered { get; }
    }
}
