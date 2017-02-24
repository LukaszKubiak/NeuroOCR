using AForge.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.NeuralNet.Learning;
using AForge.NeuralNet;

namespace NeuralNetworkOCR
{
    public partial class MainForm : Form
    {
        private static string[] fonts = new string[] { "Arial", "Courier", "Tahoma", "Times New Roman", "Verdana" };
        private bool[] regularFonts = new bool[fonts.Length];
        private bool[] italicFonts = new bool[fonts.Length];
        private int[,][] data;
        private Receptors receptors = new Receptors();
        private int initialReceptorsCount = 500;
        private int receptorsCount = 100;

        private float learningRate1 = 1.0f;
        private float errorLimit1 = 1.0f;
        private float learningRate2 = 0.2f;
        private float errorLimit2 = 0.1f;
        private int learningEpoch = 0;

        private float error = 0.0f;
        private int misclassified = 0;

        private DateTime startTime;
        private Thread workerThread;
        private ManualResetEvent stopEvent = null;
        private int workType;
        public Bitmap image { get; set; }
        System.Drawing.Graphics formGraphics;
        private Network neuralNet;


        public MainForm()
        {
            InitializeComponent();
            currentReceptorsBox.Text = initialReceptorsCount.ToString();
            receptorsBox.Text = receptorsCount.ToString();
            showReceptorsCheck.Checked = drawingArea.ShowReceptors;

            drawingArea.Receptors = receptors;

            GenerateReceptors();

            for (int i = 0; i < 26; i++)
            {
                lettersCombo.Items.Add((char)((int)'A' + i));
            }
            lettersCombo.SelectedIndex = 0;

            for (int i = 0; i < fonts.Length; i++)
            {
                fontsCombo.Items.Add(fonts[i]);
                fontsCombo.Items.Add(string.Format("{0} - Italic", fonts[i]));
            }
            fontsCombo.SelectedIndex = 0;

            UpdateAvailableFonts();

            layersCombo.SelectedIndex = 0;

            limit1Box.Text = errorLimit1.ToString();
            limit2Box.Text = errorLimit2.ToString();

        }

        private void GenerateReceptors()
        {
            receptors.Clear();
            receptors.AreaSize = drawingArea.AreaSize;
            receptors.Generate(initialReceptorsCount);
            currentReceptorsBox.Text = initialReceptorsCount.ToString();

            drawingArea.Invalidate();
        }

        private void UpdateAvailableFonts()
        {
            regularFonts[0] = arialCheck.Checked;
            regularFonts[1] = courierCheck.Checked;
            regularFonts[2] = tahomaCheck.Checked;
            regularFonts[3] = timesCheck.Checked;
            regularFonts[4] = verdanaCheck.Checked;

            italicFonts[0] = arialItalicCheck.Checked;
            italicFonts[1] = courierItalicCheck.Checked;
            italicFonts[2] = tahomaItalicCheck.Checked;
            italicFonts[3] = timesItalicCheck.Checked;
            italicFonts[4] = verdanaItalicCheck.Checked;
        }

        public void DrawLetter(char c, string fontName, float size, bool italic, bool invalidate)
        {
            int width = 500;
            int height = 500;
            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);

            if (image != null)
                image.Dispose();

            image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(whiteBrush, 0, 0, width, height);


            string str = new string(c, 1);
            Font font = new Font(fontName, size, (italic) ? FontStyle.Italic : FontStyle.Regular);
            formGraphics.DrawString(str, font, blackBrush, new Rectangle(0, 0, width, height));

            g.DrawString(str, font, blackBrush, new Rectangle(0, 0, width, height));
            g.Dispose();
            font.Dispose();
            blackBrush.Dispose();
            whiteBrush.Dispose();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            drawingArea.ShowReceptors = showReceptorsCheck.Checked;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            drawingArea.DrawLetter((char)((int)'A' + lettersCombo.SelectedIndex),
                fonts[fontsCombo.SelectedIndex >> 1], 90, ((fontsCombo.SelectedIndex & 1) != 0));
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            workType = 0;
            progressBar.Show();

            StartWork(false);
            statusBox.Text = "Generowanie danych ...";

            workerThread = new Thread(new ThreadStart(GenerateLearningData));
            workerThread.Start();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            GetReceptorsCount();
            RemoveLearningDuplicates();
            FilterLearningData();
            ShowLearningData();

            drawingArea.Receptors = receptors;
            drawingArea.Invalidate();

            currentReceptorsBox.Text = receptors.Count.ToString();
            this.Cursor = Cursors.Default;
        }

        private void StartWork(bool stopable)
        {
            this.Cursor = Cursors.WaitCursor;

           
            if (stopable)
            {
                stopEvent = new ManualResetEvent(false);
            }
            else
            {
                this.Capture = true;
            }

            startTime = DateTime.Now;
            timer.Start();
        }

        private void GenerateLearningData()
        {
            int objectsCount = 26;
            int featuresCount = receptors.Count;
            int variantsCount = 0;
            int fontsCount = fonts.Length * 2;
            int i, j, k, font, v = 0, step = 0;
            bool italic;

            for (i = 0; i < fonts.Length; i++)
            {
                variantsCount += (regularFonts[i]) ? 1 : 0;
                variantsCount += (italicFonts[i]) ? 1 : 0;
            }

            if (variantsCount == 0)
                return;
            Invoke(new Action(() =>
            {
                progressBar.Maximum = objectsCount * variantsCount;
            }));
            
            data = new int[objectsCount, featuresCount][];
            for (i = 0; i < objectsCount; i++)
            {
                for (j = 0; j < featuresCount; j++)
                {
                    data[i, j] = new int[variantsCount];
                }
            }
            for (j = 0; j < fontsCount; j++)
            {
                font = j >> 1;
                italic = ((j & 1) != 0);

                if (((italic) && (!italicFonts[font])) ||
                    ((!italic) && (!regularFonts[font])))
                {
                    continue;
                }
                for (i = 0; i < objectsCount; i++)
                {
                    drawingArea.DrawLetter((char)((int)'A' + i), fonts[font], 90, italic, false);

                    int[] state = receptors.GetReceptorsState(drawingArea.GetImage(false));
                    for (k = 0; k < featuresCount; k++)
                    {
                        data[i, k][v] = state[k];
                    }
                    Invoke(new Action(() =>
                    {
                        ReportProgress(++step, null);
                    }));
                    
                }

                v++;
            }
            drawingArea.ClearImage();
        }

        private void ReportProgress(int step, string message)
        {
            Invoke(new Action(() =>
            {
            if (progressBar.Visible)
                progressBar.Value = step;
            if (message != null)
                statusBox.Text = message;
            TimeSpan elapsed = DateTime.Now.Subtract(startTime);

            timeBox.Text = string.Format("{0}:{1}:{2}",
                elapsed.Hours.ToString("D2"),
                elapsed.Minutes.ToString("D2"),
                elapsed.Seconds.ToString("D2"));
            timeBox.Invalidate();
            }));
        }

        private void GetReceptorsCount()
        {
            try
            {
                initialReceptorsCount = Math.Max(25, Math.Min(5000, int.Parse(initialReceptorsBox.Text)));
                receptorsCount = Math.Max(10, Math.Min(initialReceptorsCount, int.Parse(receptorsBox.Text)));
            }
            catch (Exception)
            {
                initialReceptorsCount = 500;
                receptorsCount = 100;
            }
            initialReceptorsBox.Text = initialReceptorsCount.ToString();
            receptorsBox.Text = receptorsCount.ToString();
        }

        private void RemoveLearningDuplicates()
        {
            if (data == null)
                return;

            int objectsCount = data.GetLength(0);
            int featuresCount = data.GetLength(1);
            int variantsCount = data[0, 0].Length;

            int i, j, k, s;
            int[] item;

            int[,] checkSum = new int[objectsCount, featuresCount];
            for (i = 0; i < objectsCount; i++)
            {
                for (j = 0; j < featuresCount; j++)
                {
                    item = data[i, j];
                    s = 0;
                    for (k = 0; k < variantsCount; k++)
                    {
                        s |= item[k] << k;
                    }

                    checkSum[i, j] = s;
                }
            }
            bool[] remove = new bool[featuresCount];
            for (i = 0; i < featuresCount - 1; i++)
            {
                if (remove[i] == true)
                    continue;
                for (j = i + 1; j < featuresCount; j++)
                {
                    remove[j] = true;
                    for (k = 0; k < objectsCount; k++)
                    {
                        if (checkSum[k, i] != checkSum[k, j])
                        {
                            remove[j] = false;
                            break;
                        }
                    }
                }
            }
            int receptorsToSave = 0;
            for (i = 0; i < featuresCount; i++)
                receptorsToSave += (remove[i]) ? 0 : 1;

            int[,][] newData = new int[objectsCount, receptorsToSave][];
            Receptors newReceptors = new Receptors();

            k = 0;
            for (j = 0; j < featuresCount; j++)
            {
                if (remove[j])
                    continue;
                for (i = 0; i < objectsCount; i++)
                {
                    newData[i, k] = data[i, j];
                }
                newReceptors.Add(receptors[j]);
                k++;
            }
            data = newData;
            receptors = newReceptors;
        }

        private void FilterLearningData()
        {
            if (data == null)
                return;

            int objectsCount = data.GetLength(0);
            int featuresCount = data.GetLength(1);
            int variantsCount = data[0, 0].Length;
            int i, j, k, v;
            int[] item;
            if (receptorsCount >= featuresCount)
                return;

            int[] outerCounters = new int[2];
            int[] innerCounters = new int[2];
            double ie, oe;

            double[] usabilities = new double[featuresCount];
            for (j = 0; j < featuresCount; j++)
            {
                Array.Clear(outerCounters, 0, 2);

                ie = 0;
                for (i = 0; i < objectsCount; i++)
                {
                    Array.Clear(innerCounters, 0, 2);
                    item = data[i, j];

                    for (k = 0; k < variantsCount; k++)
                    {
                        v = item[k];

                        innerCounters[v]++;
                        outerCounters[v]++;
                    }
                    ie += Statistics.Entropy(innerCounters);
                }
                ie /= objectsCount;
                oe = Statistics.Entropy(outerCounters);
                usabilities[j] = (1.0 - ie) * oe;
            }
            double[] temp = (double[])usabilities.Clone();
            Array.Sort(temp);
            double accaptableUsability = temp[featuresCount - receptorsCount];
            int[,][] newData = new int[objectsCount, receptorsCount][];
            Receptors newReceptors = new Receptors();

            k = 0;
            for (j = 0; j < featuresCount; j++)
            {
                if (usabilities[j] < accaptableUsability)
                    continue;

                for (i = 0; i < objectsCount; i++)
                {
                    newData[i, k] = data[i, j];
                }
                newReceptors.Add(receptors[j]);

                if (++k == receptorsCount)
                    break;
            }
            data = newData;
            receptors = newReceptors;
        }
        private void ShowLearningData()
        {
            if (data == null)
                return;

            int objectsCount = data.GetLength(0);
            int featuresCount = data.GetLength(1);
            int variantsCount = data[0, 0].Length;
            int i, j, k;
            int[] item;

            string[,] strData = new string[objectsCount, featuresCount];
            char[] ch = new char[variantsCount];

            for (i = 0; i < objectsCount; i++)
            {
                for (j = 0; j < featuresCount; j++)
                {
                    item = data[i, j];

                    for (k = 0; k < variantsCount; k++)
                    {
                        ch[k] = (char)((int)'0' + item[k]);
                    }
                    strData[i, j] = new string(ch);
                }
            }
            dataGrid.LoadData(strData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawingArea.ClearImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetReceptorsCount();
            GenerateReceptors();
        }

        private void StopWork()
        {
            statusBox.Text = string.Empty;
            timeBox.Text = string.Empty;
            progressBar.Value = 0;
            this.Cursor = Cursors.Default;

            timer.Stop();
            if (stopEvent != null)
            {
                stopEvent.Close();
                stopEvent = null;
            }
            else
            {
                this.Capture = false;
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            if (!workerThread.IsAlive)
            {
                switch (workType)
                {
                    case 0:    
                        ShowLearningData();
                        filterButton.Enabled = true;
                        break;

                    case 1:    
                        if (data != null)
                        {
                            errorBox.Text = error.ToString();
                            misclassifiedBox.Text = string.Format("{0} / {1}",
                                misclassified, data.GetLength(0) * data[0, 0].Length);
                        }
                        break;
                }
                StopWork();
            }
        }

        private void fontCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateAvailableFonts();
        }

        private void createNetButton_Click(object sender, EventArgs e)
        {
            CreateNetwork();

            traintNetworkButton.Enabled = true;
            recognizeButton.Enabled = true;

            errorBox.Text = string.Empty;
            misclassifiedBox.Text = string.Empty;
            outputBox.Text = string.Empty;
        }

        private void CreateNetwork()
        {
            if (data == null)
                return;

            int objectsCount = data.GetLength(0);
            int featuresCount = data.GetLength(1);
            float alfa;
            try
            {
                alfa = Math.Max(0.1f, Math.Min(10.0f, float.Parse("1")));
            }
            catch (Exception)
            {
                alfa = 1.0f;
            }
            if (layersCombo.SelectedIndex == 0)
            {
                neuralNet = new Network(new BipolarSigmoidFunction(alfa), featuresCount, objectsCount);
            }
            else
            {
                neuralNet = new Network(new BipolarSigmoidFunction(alfa), featuresCount, objectsCount, objectsCount);
            }
            neuralNet.Randomize();
        }

        private void traintNetworkButton_Click(object sender, EventArgs e)
        {
            outputBox.Text = string.Empty;
            try
            {
                learningEpoch = Math.Max(0, int.Parse("0"));
                learningRate1 = Math.Max(0.0001f, Math.Min(10.0f, learningRate1));
                errorLimit1 = Math.Max(0.0001f, Math.Min(1000.0f, float.Parse(limit1Box.Text)));
                learningRate2 = Math.Max(0.0001f, Math.Min(10.0f, learningRate2));
                errorLimit2 = Math.Max(0.0001f, Math.Min(1000.0f, float.Parse(limit2Box.Text)));
            }
            catch (Exception)
            {
                learningEpoch = 0;
                learningRate1 = 1.0f;
                errorLimit1 = 1.0f;
                learningRate2 = 0.2f;
                errorLimit2 = 0.1f;
            }
            limit1Box.Text = errorLimit1.ToString();
            limit2Box.Text = errorLimit2.ToString();

            workType = 1;
            progressBar.Hide();
            StartWork(true);

            statusBox.Text = "Uczenie sieci ...";
            workerThread = new Thread(new ThreadStart(TrainNetwork));
            workerThread.Start();

        }

        private void TrainNetwork()
        {
            if (data == null)
                return;

            int objectsCount = data.GetLength(0);
            int featuresCount = data.GetLength(1);
            int variantsCount = data[0, 0].Length;
            int i, j, k, n;

            float[][] possibleOutputs = new float[objectsCount][];

            for (i = 0; i < objectsCount; i++)
            {
                possibleOutputs[i] = new float[objectsCount];
                for (j = 0; j < objectsCount; j++)
                {
                    possibleOutputs[i][j] = (i == j) ? 0.5f : -0.5f;
                }
            }
            float[][] input = new float[objectsCount * variantsCount][];
            float[][] output = new float[objectsCount * variantsCount][];
            float[] ins;

            for (j = 0, n = 0; j < variantsCount; j++)
            {
                for (i = 0; i < objectsCount; i++, n++)
                {
                    input[n] = ins = new float[featuresCount];
                    for (k = 0; k < featuresCount; k++)
                    {
                        ins[k] = (float)data[i, k][j] - 0.5f;
                    }
                    output[n] = possibleOutputs[i];
                }
            }

            System.Diagnostics.Debug.WriteLine("--- uczenie....");
            BackPropagationLearning teacher = new BackPropagationLearning(neuralNet);

            teacher.LearningLimit = errorLimit1;
            teacher.LearningRate = learningRate1;

            i = 0;
            do
            {
                error = teacher.LearnEpoch(input, output);
                i++;
                if ((i % 100) == 0)
                {
                    ReportProgress(0, string.Format("Uczenie, 1 cykl ... (iteracji: {0}, błąd: {1})",
                        i, error));
                }
                if (stopEvent.WaitOne(0, true))
                    break;
            }
            while (((learningEpoch == 0) && (!teacher.IsConverged)) ||
                ((learningEpoch != 0) && (i < learningEpoch)));

            System.Diagnostics.Debug.WriteLine("first pass: " + i + ", error = " + error);
            if (learningEpoch == 0)
            {
                teacher = new BackPropagationLearning(neuralNet);

                teacher.LearningLimit = errorLimit2;
                teacher.LearningRate = learningRate2;
                do
                {
                    error = teacher.LearnEpoch(input, output);
                    i++;
                    if ((i % 100) == 0)
                    {
                        ReportProgress(0, string.Format("Uczenie, 2 cykl ... (iteracji: {0}, błąd: {1})",
                            i, error));
                    }
                    if (stopEvent.WaitOne(0, true))
                        break;
                }
                while (!teacher.IsConverged);

                System.Diagnostics.Debug.WriteLine("second pass: " + i + ", error = " + error);
            }

            misclassified = 0;
            for (i = 0, n = input.Length; i < n; i++)
            {
                float[] realOutput = neuralNet.Compute(input[i]);
                float[] desiredOutput = output[i];
                int maxIndex1 = 0;
                int maxIndex2 = 0;
                float max1 = realOutput[0];
                float max2 = desiredOutput[0];

                for (j = 1, k = realOutput.Length; j < k; j++)
                {
                    if (realOutput[j] > max1)
                    {
                        max1 = realOutput[j];
                        maxIndex1 = j;
                    }
                    if (desiredOutput[j] > max2)
                    {
                        max2 = desiredOutput[j];
                        maxIndex2 = j;
                    }
                }

                if (maxIndex1 != maxIndex2)
                    misclassified++;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (stopEvent != null)
                stopEvent.Set();
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            int i, n, maxIndex = 0;
            int[] state = receptors.GetReceptorsState(drawingArea.GetImage());

            float[] input = new float[state.Length];

            for (i = 0; i < state.Length; i++)
                input[i] = (float)state[i] - 0.5f;

            float[] output = neuralNet.Compute(input);
            float max = output[0];
            for (i = 1, n = output.Length; i < n; i++)
            {
                if (output[i] > max)
                {
                    max = output[i];
                    maxIndex = i;
                }
            }
            outputBox.Text = string.Format("{0}", (char)((int)'A' + maxIndex));
        }
    }
}
