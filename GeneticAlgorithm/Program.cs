using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Xover;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Populations;
using GeneticAlgorithm.Randomization;
using GeneticAlgorithm.Algorithms;
using GeneticAlgorithm.Controllers.ImageApproximation;


namespace GeneticAlgorithm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGAWindow());
        }
       
    }
}
