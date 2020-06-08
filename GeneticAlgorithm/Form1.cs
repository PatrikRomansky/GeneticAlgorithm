using GeneticAlgorithm.Algorithms;
using GeneticAlgorithm.Controllers;
using GeneticAlgorithm.Controllers.ImageApproximation;
using GeneticAlgorithm.Populations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    public partial class FormGAWindow : Form
    {

        private string imgTargetFileName;
        private Thread threadGA;
        private GA ga;


        public FormGAWindow()
        {
            InitializeComponent();
            comboBoxControllers.Items.AddRange(selectType<IController>());
        }

        private void selectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                imgTargetFileName = of.FileName;
                pictureBoxTarget.Image = Bitmap.FromFile(of.FileName) as Bitmap;
            }
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (buttonStartStop.Text == "START")
            {

                if (configGa())
                {
                    buttonStartStop.Text = "STOP";
                    threadGA = new Thread(ga.Run);

                    threadGA.Start();

                }

            }
            else
            {
                buttonStartStop.Text = "START";
                ga.Stop();
                threadGA.Abort();
            }
        }

        private bool configGa()
        {

            string target;
            Type controlerName;
            try
            {
                target = imgTargetFileName.Replace("\\", "/");

            }
            catch
            {
                MessageBox.Show("The input image must be set.", "Error: input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                controlerName = controllers[comboBoxControllers.SelectedItem.ToString()];
            }
            catch
            {
                MessageBox.Show("The controller must be set.", "Error: controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var sampleController = Activator.CreateInstance(controlerName) as IController;

            sampleController.Initialize(target);

            var selection = sampleController.CreateSelection();
            var crossover = sampleController.CreateCrossover();
            var mutation = sampleController.CreateMutation();
            var fitness = sampleController.CreateFitness();
            var elitizmus = sampleController.CreateElitizmus();
            var executor = sampleController.CreateExecutor();
            var population = new Population(20, sampleController.CreateIndividual);

            ga = new GA(population, fitness, selection, crossover, mutation, elitizmus, executor);
            ga.Termination = sampleController.CreateTermination();

            var terminationName = ga.Termination.GetType().Name;

            ga.GenerationInfo += delegate
            {
                var bestIndividual = ga.Population.BestIndividual;

                SetControlPropertyThreadSafe(labelTime, "Text", "Time: " + ga.TimeEvolving);
                SetControlPropertyThreadSafe(labelFitness, "Text", "Fitness: " + bestIndividual.Fitness);
                SetControlPropertyThreadSafe(labelGeneration, "Text", "Generations: " + ga.Population.CurrentGenerationNumber);

                var speed = ga.TimeEvolving.TotalSeconds / ga.Population.CurrentGenerationNumber;
                SetControlPropertyThreadSafe(labelSpeed, "Text", "Speed(gen / sec):" + speed.ToString("0.0000"));

                var best = sampleController.ShowBestIndividual(bestIndividual);

                if (best != null)
                {
                    SetControlPropertyThreadSafe(pictureBoxBestInd, "Image", Bitmap.FromFile(best.ToString()));
                }
            };

            sampleController.ConfigGA(ga);
            return true;
        }

        Dictionary<string, Type> controllers = new Dictionary<string, Type>();

        private string[] selectType<TInterface>()
        {
            var type = typeof(TInterface);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) & p.IsClass & !p.IsAbstract).ToArray();

            string[] result = new string[types.Length];
            int i = 0;

            foreach (var t in types)
            {
                result[i++] = t.Name;
                controllers.Add(t.Name, t);
            }

            return result;
        }


        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (threadGA != null)
            {
                ga.Stop();
                threadGA.Abort();
            }
        }
    }
}
