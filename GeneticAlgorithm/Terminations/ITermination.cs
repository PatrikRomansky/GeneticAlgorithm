using GeneticAlgorithm.Algorithms;

namespace GeneticAlgorithm.Terminations
{
    public interface ITermination
    {
        /// <summary>
        /// Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <returns>True if termination has been reached, otherwise false.</returns>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        bool IsFulfilled(IGeneticlgorithm geneticAlgorithm);
    }
}
