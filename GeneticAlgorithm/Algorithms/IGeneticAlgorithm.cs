using System;
using System.Collections.Generic;
using GeneticAlgorithm.Individuals;

namespace GeneticAlgorithm.Algorithms
{
    public enum GeneticAlgorithmState
    {
        /// <summary>
        /// The GA has not been started yet.
        /// </summary>
        NotStarted,

        /// <summary>
        /// The GA has been started and is running.
        /// </summary>
        Started,

        /// <summary>
        /// The GA has been stopped and is not running.
        /// </summary>
        Stopped,

        /// <summary>
        /// The GA has been resumed after a stop or termination reach and is running.
        /// </summary>
        Resumed,

        /// <summary>
        /// The GA has reach the termination condition and is not running.
        /// </summary>
        TerminationReached
    }

    public interface IGeneticlgorithm
    {        
        /// <summary>
        /// Gets the generations number.
        /// </summary>
        /// <value>The generations number.</value>
        int GenerationsNumber { get; }

        /// <summary>
        /// Gets the best chromosome.
        /// </summary>
        /// <value>The best chromosome.</value>
        IIndividual BestIndividual { get; }

        /// <summary>
        /// Gets the time evolving.
        /// </summary>
        /// <value>The time evolving.</value>
        TimeSpan TimeEvolving { get; }

        IList<IIndividual> Cross(IList<IIndividual> parents);
        void Mutate(IList<IIndividual> individials);

        /// <summary>
        /// Run GA.
        /// </summary>
        void Run();

        /// <summary>
        /// Stop GA(evolution);
        /// </summary>
        void Stop();
    }
}
