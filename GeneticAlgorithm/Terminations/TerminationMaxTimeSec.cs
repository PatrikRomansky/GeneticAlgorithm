using GeneticAlgorithm.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Terminations
{
    class TerminationMaxTimeSec : ITermination
    {
        /// <summary>
        /// Gets the execution max time.
        /// </summary>
        /// <value>The max time.</value>
        public TimeSpan MaxTime { get;}

        public TerminationMaxTimeSec(TimeSpan maxTime)
        {
            MaxTime = maxTime;
        }

        public bool IsFulfilled(IGeneticlgorithm geneticAlgorithm)
        {
            if (geneticAlgorithm.TimeEvolving < MaxTime)
            {
                return false;
            }

            return true;
        }
    }
}
