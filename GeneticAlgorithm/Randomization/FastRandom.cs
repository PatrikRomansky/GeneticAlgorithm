using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Randomization
{
    class FastRandom
    {
        const double REAL_UNIT_INT = 1.0 / ((double)int.MaxValue + 1.0);
        const double REAL_UNIT_UINT = 1.0 / ((double)uint.MaxValue + 1.0);
        const uint Y = 842502087, Z = 3579807591, W = 273326509;
        uint x, y, z, w;

        #region Constructors
        /// <summary>
        /// Initialises a new instance using an int value as seed.
        /// This constructor signature is provided to maintain compatibility with
        /// System.Random
        /// </summary>
        public FastRandom(int seed)
        {
            Reinitialize(seed);
        }

        #endregion

        #region Public Methods [Reinitialisation]

        /// <summary>
        /// Reinitialises using an int value as a seed.
        /// </summary>
        /// <param name="seed"></param>
        public void Reinitialize(int seed)
        {

            x = (uint)seed;
            y = Y;
            z = Z;
            w = W;
        }

        #endregion

     
        /// <summary>
        /// Generates a random int over the range lowerBound to upperBound-1, and not including upperBound.
        /// upperBound must be >= lowerBound. lowerBound may be negative.
        /// </summary>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public int Next(int lowerBound, int upperBound)
        {
            if (lowerBound > upperBound)
                throw new ArgumentOutOfRangeException("upperBound", upperBound, "upperBound must be >=lowerBound");

            uint t = (x ^ (x << 11));
            x = y; y = z; z = w;

            int range = upperBound - lowerBound;
            if (range < 0)
            {   
                return lowerBound + (int)((REAL_UNIT_UINT * (double)(w = (w ^ (w >> 19)) ^ (t ^ (t >> 8)))) * (double)((long)upperBound - (long)lowerBound));
            }

            return lowerBound + (int)((REAL_UNIT_INT * (double)(int)(0x7FFFFFFF & (w = (w ^ (w >> 19)) ^ (t ^ (t >> 8))))) * (double)range);
        }

        /// <summary>
        /// Generates a random double. Values returned are from 0.0 up to but not including 1.0.
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            uint t = (x ^ (x << 11));
            x = y; y = z; z = w;

            return (REAL_UNIT_INT * (int)(0x7FFFFFFF & (w = (w ^ (w >> 19)) ^ (t ^ (t >> 8)))));
        }
    }
}
