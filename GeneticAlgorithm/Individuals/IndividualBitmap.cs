﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GeneticAlgorithm.Genes;
using GeneticAlgorithm.Randomization;

namespace GeneticAlgorithm.Individuals
{
    public class IndividualBitmap : Individual
    {
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; private set; }

        /// <summary>
        /// Initializes a new instance of the IndividualBitmap.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="init">Initilaization genes.</param>
        public IndividualBitmap(int width, int height, bool init = true)
            : base(width * height)
        {
            Width = width;
            Height = height;
           
            if (init)
            {
                Initialize();
            }
        }

        /// <summary>
        /// Gets the pixels from bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>The pixels.</returns>
        public static IList<Color> GetPixels(Bitmap bitmap)
        {
            var pixels = new List<Color>();
            var width = bitmap.Width;
            var height = bitmap.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixels.Add(bitmap.GetPixel(x, y));
                }
            }

            return pixels;
        }

        /// <summary>
        /// Generates the gene.
        /// </summary>
        /// <param name="geneIndex">Index of the gene.</param>
        /// <returns>The new Gene.</returns>
        public override Gene GenerateGene()
        {
            return new Gene(Color.FromArgb(RandomizationRnd.GetInt(0, 256), RandomizationRnd.GetInt(0, 256), RandomizationRnd.GetInt(0, 256)));
        }

        /// <summary>
        /// Creates a new individual using the same structure of this.
        /// </summary>
        /// <returns>
        /// The new individual.
        /// </returns>
        public override IIndividual CreateNew()
        {
            return new IndividualBitmap(Width, Height, false);
        }
        
        /// <summary>
        /// Builds the bitmap from genes.
        /// </summary>
        /// <returns>The bitmap.</returns>
        public Bitmap BuildBitmap()
        {
            var result = new Bitmap(Width, Height);
            var geneIndex = 0;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    result.SetPixel(x, y, (Color)GetGene(geneIndex++).Value);
                }
            }

            return result;
        }
    }
}
