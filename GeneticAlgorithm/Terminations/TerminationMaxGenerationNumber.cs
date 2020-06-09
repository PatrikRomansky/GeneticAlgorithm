using GeneticAlgorithm.Algorithms;


namespace GeneticAlgorithm.Terminations
{
    public class TerminationMaxGenerationNumber : ITermination
    {
        int ExpectedGenerationsNumber { get;}

        /// <summary>
        /// Termination max. generation number.
        /// </summary>
        /// <param name="expectedGenerationNumber"> Max. generation.</param>
        public TerminationMaxGenerationNumber(int expectedGenerationNumber)
        {
            ExpectedGenerationsNumber = expectedGenerationNumber;
        }

        /// <summary>
        /// Determines whether the specified geneticAlgorithm reached the termination condition.
        /// </summary>
        /// <returns>True if termination has been fulfilled, otherwise false.</returns>
        /// <param name="geneticAlgorithm">The genetic algorithm.</param>
        public bool IsFulfilled(IGeneticlgorithm geneticAlgorithm)
        {
            if (geneticAlgorithm.GenerationsNumber < ExpectedGenerationsNumber)
            {
                return false;
            }

            return true;
        }
    }
}
