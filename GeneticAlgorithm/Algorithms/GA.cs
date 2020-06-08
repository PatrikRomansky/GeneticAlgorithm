using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GeneticAlgorithm.Individuals;
using GeneticAlgorithm.Populations;
using GeneticAlgorithm.Fitnesses;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Xover;
using GeneticAlgorithm.Selections;
using GeneticAlgorithm.Terminations;
using GeneticAlgorithm.Randomization;
using GeneticAlgorithm.Elitizmus;
using GeneticAlgorithm.Executor;

namespace GeneticAlgorithm.Algorithms
{
    public class GA : IGeneticlgorithm
    {
        protected Stopwatch m_stopwatch;
        
        /// <summary>
        /// Occurs when generation ran.
        /// </summary>
        public event EventHandler GenerationInfo;

        /// <summary>
        /// Occurs when termination reached.
        /// </summary>
        public event EventHandler TerminationReached;

        /// <summary>
        /// Gets the population.
        /// </summary>
        /// <value>The population.</value>
        public IPopulation Population { get; protected set; }

        /// <summary>
        /// Gets the fitness function.
        /// </summary>
        public IFitness Fitness { get; protected set; }

        /// <summary>
        /// Gets or sets the selection operator.
        /// </summary>
        public ISelection Selection { get; set; }

        /// <summary>
        /// Gets or sets the crossover operator.
        /// </summary>
        /// <value>The crossover.</value>
        public IXover Xover { get; set; }

        /// <summary>
        /// Gets or sets the crossover probability.
        /// </summary>
        public float XoverProbability { get; set; }

        /// <summary>
        /// Gets or sets the mutation operator.
        /// </summary>
        public IMutation Mutation { get; set; }

        /// <summary>
        /// Gets or sets the mutation probability.
        /// </summary>
        public float MutationProbability { get; set; }

        /// <summary>
        /// Gets or sets the termination condition.
        /// </summary>
        public ITermination Termination { get; set; }

        public IElitizmus Elitizmus { get; set; }


        public IExecutor Executor { get; set; }

        /// <summary>
        /// Gets the generations number.
        /// </summary>
        /// <value>The generations number.</value>
        public int GenerationsNumber
        {
            get => Population.CurrentGenerationNumber;
        }

        /// <summary>
        /// Gets the best chromosome.
        /// </summary>
        /// <value>The best chromosome.</value>
        public IIndividual BestIndividual
        {
            get => Population.BestIndividual;
        }

        /// <summary>
        /// Gets the time evolving.
        /// </summary>
        public TimeSpan TimeEvolving { get; protected set; }

        public GA() { }

        public GA(IPopulation population, IFitness fitness, ISelection selection, IXover xover, IMutation mutation, IElitizmus elitizmus, IExecutor executor)
        {
            Population = population;
            Fitness = fitness;
            Selection = selection;
            Xover = xover;
            Mutation = mutation;
            Elitizmus = elitizmus;
            Executor = executor;

            Termination = new TerminationMaxGenerationNumber(2);
            XoverProbability = 0.5f;
            MutationProbability = 0.5f;
            TimeEvolving = TimeSpan.Zero;

        }
        volatile bool terminationConditionReached = false;

        /// <summary>
        /// Starts the genetic algorithm using population, fitness, selection, crossover, mutation and termination configured.
        /// </summary>
        public void Run()
        {
                m_stopwatch = Stopwatch.StartNew();
                Population.CreateInitialPopulation();
                m_stopwatch.Stop();
                TimeEvolving = m_stopwatch.Elapsed;



            if (EndCurrentGeneration())
            {
                return;
            }

            do
            {
                m_stopwatch.Restart();
                terminationConditionReached = EvolveOneGeneration();
                m_stopwatch.Stop();
                TimeEvolving += m_stopwatch.Elapsed;
            }
            while (!terminationConditionReached);
        }


        public void Stop()
        {
            terminationConditionReached = true;
        }


        /// <summary>
        /// Evolve one generation.
        /// </summary>
        /// <returns>True if termination has been reached, otherwise false.</returns>
        protected bool EvolveOneGeneration()
        {
            
            var parents = SelectParents();
            // var offspring = parents;
            // Console.WriteLine(parents.Count);
            var offspring = Cross(parents);

            // Console.WriteLine(offspring.Count);
            Mutate(offspring);


            offspring = SelectElite(offspring, parents);

            Population.CreateNewGeneration(offspring);
            return EndCurrentGeneration();
        }

        /// <summary>
        /// Ends the current generation.
        /// </summary>
        /// <returns><c>true</c>, if current generation was ended, <c>false</c> otherwise.</returns>
        protected bool EndCurrentGeneration()
        {
            EvaluateFitness();
            Population.EndCurrentGeneration();

            var handler = GenerationInfo;
            handler?.Invoke(this, EventArgs.Empty);

            if (Termination.IsFulfilled(this))
            {

                handler = TerminationReached;
                handler?.Invoke(this, EventArgs.Empty);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Evaluates the fitness.
        /// </summary>
        protected void EvaluateFitness()
        {
            Executor.EvaluateFitness(Fitness, Population);
        }

        /// <summary>
        /// Selects the parents.
        /// </summary>
        /// <returns>The parents.</returns>
        protected IList<IIndividual> SelectParents()
        {
            return Selection.SelectIndividuals(Population.Size, Population);
        }

        /// <summary>
        /// Crosses the specified parents.
        /// </summary>
        /// <param name="parents">The parents.</param>
        /// <returns>The result individuals.</returns>
        public IList<IIndividual> Cross(IList<IIndividual> parents)
        {
            return Executor.Cross(Population, Xover, XoverProbability, parents);
        }

        private double? previuosBestFit = 0; 
        /// <summary>
        /// Mutate the specified individuals.
        /// </summary>
        /// <param name="individuals">The individuals.</param>
        public void Mutate(IList<IIndividual> individuals)
        {
           var fit = BestIndividual.Fitness;
            if (fit != null & previuosBestFit * 1.5 <= fit)
            {
                previuosBestFit = fit;
                Mutation.Adaptive();
            }


            Executor.Mutate(Mutation, MutationProbability, individuals);
        }


        protected IList<IIndividual> SelectElite(IList<IIndividual> offspring, IList<IIndividual> parents) 
        {
            return Elitizmus.EliteIndividuals(Population.Size, offspring, parents);
        }
    }
}
