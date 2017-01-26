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
using NeuralNetwork;
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
            //formGraphics = this.CreateGraphics();

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
            // remove previous receptors
            receptors.Clear();
            // set reception area size
            receptors.AreaSize = drawingArea.AreaSize;
            // generate new receptors
            receptors.Generate(initialReceptorsCount);
            // set current receptors count
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

            /*generateDataButton.Enabled =
                regularFonts[0] | regularFonts[1] | regularFonts[2] | regularFonts[3] | regularFonts[4] |
                italicFonts[0] | italicFonts[1] | italicFonts[2] | italicFonts[3] | italicFonts[4];*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

            receptors.Clear();
            formGraphics.Clear(Color.White);
            receptors.size = new Size(500, 500);
            receptors.Generate(1500);

            
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            DrawLetter('A', "Arial", 350, false, false);
            for (int i = 0; i < receptors.Count; i++)
            {
                formGraphics.DrawLine(myPen, receptors[i].x1, receptors[i].y1, receptors[i].x2, receptors[i].y2);
                
            }
            int[] state = receptors.GetReceptorsState(image);

            formGraphics.Clear(Color.White);
            DrawLetter('A', "Arial", 350, false, false);
            for (int i = 0; i < state.Length; i++)
            {
                if(state[i] == 1)
                    formGraphics.DrawLine(myPen, receptors[i].x1, receptors[i].y1, receptors[i].x2, receptors[i].y2);
            }

            formGraphics.Clear(Color.White);
            DrawLetter('A', "Courier", 350, false, false);
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] == 1)
                    formGraphics.DrawLine(myPen, receptors[i].x1, receptors[i].y1, receptors[i].x2, receptors[i].y2);
            }

            

            formGraphics.Clear(Color.White);
            DrawLetter('B', "Courier", 350, false, false);
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] == 1)
                    formGraphics.DrawLine(myPen, receptors[i].x1, receptors[i].y1, receptors[i].x2, receptors[i].y2);
            }

            myPen.Dispose();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            // start thread
            workerThread.Start();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            GetReceptorsCount();

            // filter data
            RemoveLearningDuplicates();
            FilterLearningData();
            ShowLearningData();

            // set receptors for paint board
            drawingArea.Receptors = receptors;
            drawingArea.Invalidate();

            // set current receptors count
            currentReceptorsBox.Text = receptors.Count.ToString();

            /*traintNetworkButton.Enabled = false;
            recognizeButton.Enabled = false;*/

            // set default cursor
            this.Cursor = Cursors.Default;
        }

        private void StartWork(bool stopable)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

           
            if (stopable)
            {
                // create events
                stopEvent = new ManualResetEvent(false);
            }
            else
            {
                this.Capture = true;
            }

            // generate data in separate thread
            startTime = DateTime.Now;

            // start timer
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

            // count variants
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
            

            // create data array
            data = new int[objectsCount, featuresCount][];
            // init each data element
            for (i = 0; i < objectsCount; i++)
            {
                for (j = 0; j < featuresCount; j++)
                {
                    data[i, j] = new int[variantsCount];
                }
            }

            // fill data ...

            // for all fonts
            for (j = 0; j < fontsCount; j++)
            {
                font = j >> 1;
                italic = ((j & 1) != 0);

                // skip disabled fonts
                if (((italic) && (!italicFonts[font])) ||
                    ((!italic) && (!regularFonts[font])))
                {
                    continue;
                }

                // for all objects
                for (i = 0; i < objectsCount; i++)
                {
                    // draw letter
                    drawingArea.DrawLetter((char)((int)'A' + i), fonts[font], 90, italic, false);

                    // get receptors state
                    int[] state = receptors.GetReceptorsState(drawingArea.GetImage(false));

                    // copy receptors state
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

            // clear paint area
            drawingArea.ClearImage();
        }

        private void ReportProgress(int step, string message)
        {
            Invoke(new Action(() =>
            {
            // display progress
            if (progressBar.Visible)
                progressBar.Value = step;

            // display message
            if (message != null)
                statusBox.Text = message;

            // display elapsed time
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

            // calculate checksum of each object for each receptor
            int[,] checkSum = new int[objectsCount, featuresCount];

            // for each object
            for (i = 0; i < objectsCount; i++)
            {
                // for each receptor
                for (j = 0; j < featuresCount; j++)
                {
                    item = data[i, j];
                    s = 0;

                    // for each variant
                    for (k = 0; k < variantsCount; k++)
                    {
                        s |= item[k] << k;
                    }

                    checkSum[i, j] = s;
                }
            }

            // find which receptors should be removed
            bool[] remove = new bool[featuresCount];

            // walk through all receptors ...
            for (i = 0; i < featuresCount - 1; i++)
            {
                // skip receptors alredy marked as deleted
                if (remove[i] == true)
                    continue;

                // ... and compare each receptor with others
                for (j = i + 1; j < featuresCount; j++)
                {
                    // remove by default
                    remove[j] = true;

                    // compare cheksums of all objects
                    for (k = 0; k < objectsCount; k++)
                    {
                        if (checkSum[k, i] != checkSum[k, j])
                        {
                            // ups, they are different, do not delete it
                            remove[j] = false;
                            break;
                        }
                    }
                }
            }

            // count receptors to save
            int receptorsToSave = 0;
            for (i = 0; i < featuresCount; i++)
                receptorsToSave += (remove[i]) ? 0 : 1;

            // filter data removing receptors with usability below acceptable
            int[,][] newData = new int[objectsCount, receptorsToSave][];
            Receptors newReceptors = new Receptors();

            k = 0;
            // for all receptors
            for (j = 0; j < featuresCount; j++)
            {
                if (remove[j])
                    continue;

                // for all objects
                for (i = 0; i < objectsCount; i++)
                {
                    newData[i, k] = data[i, j];
                }
                newReceptors.Add(receptors[j]);
                k++;
            }

            // set new data
            data = newData;
            receptors = newReceptors;
        }

        // Filter learning data
        private void FilterLearningData()
        {
            if (data == null)
                return;

            // data filtering is performed by removing bad receptors

            int objectsCount = data.GetLength(0);
            int featuresCount = data.GetLength(1);
            int variantsCount = data[0, 0].Length;
            int i, j, k, v;
            int[] item;

            // maybe we already filtered ?
            // so check that new receptors count is not greater than we have
            if (receptorsCount >= featuresCount)
                return;

            int[] outerCounters = new int[2];
            int[] innerCounters = new int[2];
            double ie, oe;

            double[] usabilities = new double[featuresCount];

            // for all receptors
            for (j = 0; j < featuresCount; j++)
            {
                // clear outer counters
                Array.Clear(outerCounters, 0, 2);

                ie = 0;
                // for all objects
                for (i = 0; i < objectsCount; i++)
                {
                    // clear inner counters
                    Array.Clear(innerCounters, 0, 2);
                    // get variants item
                    item = data[i, j];

                    // for all variants
                    for (k = 0; k < variantsCount; k++)
                    {
                        v = item[k];

                        innerCounters[v]++;
                        outerCounters[v]++;
                    }

                    // callculate inner entropy of receptor for current object
                    ie += Statistics.Entropy(innerCounters);
                }

                // average inner entropy
                ie /= objectsCount;
                // outer entropy
                oe = Statistics.Entropy(outerCounters);
                // receptors usability
                usabilities[j] = (1.0 - ie) * oe;
            }

            // create usabilities copy and sort it
            double[] temp = (double[])usabilities.Clone();
            Array.Sort(temp);
            // get acceptable usability for receptor
            double accaptableUsability = temp[featuresCount - receptorsCount];

            // filter data removing receptors with usability below acceptable
            int[,][] newData = new int[objectsCount, receptorsCount][];
            Receptors newReceptors = new Receptors();

            k = 0;
            // for all receptors
            for (j = 0; j < featuresCount; j++)
            {
                if (usabilities[j] < accaptableUsability)
                    continue;

                // for all objects
                for (i = 0; i < objectsCount; i++)
                {
                    newData[i, k] = data[i, j];
                }
                newReceptors.Add(receptors[j]);

                if (++k == receptorsCount)
                    break;
            }

            // set new data
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

            // string data
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

            // show data
            dataGrid.LoadData(strData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawingArea.ClearImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetReceptorsCount();

            // generate
            GenerateReceptors();

            /*// disable train and recognize buttons
            traintNetworkButton.Enabled = false;
            recognizeButton.Enabled = false;*/
        }

        private void StopWork()
        {
            statusBox.Text = string.Empty;
            timeBox.Text = string.Empty;
            progressBar.Value = 0;

            // set default cursor
            this.Cursor = Cursors.Default;

            // stop timer
            timer.Stop();

            // release event
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
                    case 0:     // generate data
                                // show learning data
                        ShowLearningData();

                        // enable data filtering
                        filterButton.Enabled = true;

                        /*// disable train and recognize buttons
                        traintNetworkButton.Enabled = false;
                        recognizeButton.Enabled = false;*/

                        break;

                    case 1:     // training network
                                // last error
                        if (data != null)
                        {
                            errorBox.Text = error.ToString();
                            misclassifiedBox.Text = string.Format("{0} / {1}",
                                misclassified, data.GetLength(0) * data[0, 0].Length);
                        }
                        break;
                }

                // stop work
                StopWork();
            }
        }

        private void fontCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateAvailableFonts();
        }

        private void label14_Click(object sender, EventArgs e)
        {

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

            // get alfa value
            try
            {
                alfa = Math.Max(0.1f, Math.Min(10.0f, float.Parse("1")));
            }
            catch (Exception)
            {
                alfa = 1.0f;
            }

            // creare network
            if (layersCombo.SelectedIndex == 0)
            {
                neuralNet = new Network(new BipolarSigmoidFunction(alfa), featuresCount, objectsCount);
            }
            else
            {
                neuralNet = new Network(new BipolarSigmoidFunction(alfa), featuresCount, objectsCount, objectsCount);
            }

            // randomize network`s weights
            neuralNet.Randomize();
        }

        private void traintNetworkButton_Click(object sender, EventArgs e)
        {
            outputBox.Text = string.Empty;

            // get parameters
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

            //
            workType = 1;
            progressBar.Hide();

            // start work
            StartWork(true);

            // set status message
            statusBox.Text = "Uczenie sieci ...";

            // create and start new thread
            workerThread = new Thread(new ThreadStart(TrainNetwork));
            // start thread
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

            // generate possible outputs
            float[][] possibleOutputs = new float[objectsCount][];

            for (i = 0; i < objectsCount; i++)
            {
                possibleOutputs[i] = new float[objectsCount];
                for (j = 0; j < objectsCount; j++)
                {
                    possibleOutputs[i][j] = (i == j) ? 0.5f : -0.5f;
                }
            }

            // generate network training data
            float[][] input = new float[objectsCount * variantsCount][];
            float[][] output = new float[objectsCount * variantsCount][];
            float[] ins;

            // for all varaints
            for (j = 0, n = 0; j < variantsCount; j++)
            {
                // for all objects
                for (i = 0; i < objectsCount; i++, n++)
                {
                    // prepare input
                    input[n] = ins = new float[featuresCount];

                    // for each receptor
                    for (k = 0; k < featuresCount; k++)
                    {
                        ins[k] = (float)data[i, k][j] - 0.5f;
                    }

                    // set output
                    output[n] = possibleOutputs[i];
                }
            }

            System.Diagnostics.Debug.WriteLine("--- learning started");

            // create network teacher
            BackPropagationLearning teacher = new BackPropagationLearning(neuralNet);

            // First pass
            teacher.LearningLimit = errorLimit1;
            teacher.LearningRate = learningRate1;

            i = 0;
            // learn
            do
            {
                error = teacher.LearnEpoch(input, output);
                i++;

                // report status
                if ((i % 100) == 0)
                {
                    ReportProgress(0, string.Format("Uczenie, 1 cykl ... (iteracji: {0}, błąd: {1})",
                        i, error));
                }

                // need to stop ?
                if (stopEvent.WaitOne(0, true))
                    break;
            }
            while (((learningEpoch == 0) && (!teacher.IsConverged)) ||
                ((learningEpoch != 0) && (i < learningEpoch)));

            System.Diagnostics.Debug.WriteLine("first pass: " + i + ", error = " + error);

            // skip second pass, if learning epoch number was specified
            if (learningEpoch == 0)
            {
                // Second pass
                teacher = new BackPropagationLearning(neuralNet);

                teacher.LearningLimit = errorLimit2;
                teacher.LearningRate = learningRate2;

                // learn
                do
                {
                    error = teacher.LearnEpoch(input, output);
                    i++;

                    // report status
                    if ((i % 100) == 0)
                    {
                        ReportProgress(0, string.Format("Uczenie, 2 cykl ... (iteracji: {0}, błąd: {1})",
                            i, error));
                    }

                    // need to stop ?
                    if (stopEvent.WaitOne(0, true))
                        break;
                }
                while (!teacher.IsConverged);

                System.Diagnostics.Debug.WriteLine("second pass: " + i + ", error = " + error);
            }

            // get the misclassified value
            misclassified = 0;
            // for all training patterns
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

            // get current receptors state
            int[] state = receptors.GetReceptorsState(drawingArea.GetImage());

            // for network input
            float[] input = new float[state.Length];

            for (i = 0; i < state.Length; i++)
                input[i] = (float)state[i] - 0.5f;

            // compute network and get it's ouput
            float[] output = neuralNet.Compute(input);

            // find the maximum from output
            float max = output[0];
            for (i = 1, n = output.Length; i < n; i++)
            {
                if (output[i] > max)
                {
                    max = output[i];
                    maxIndex = i;
                }
            }

            //
            outputBox.Text = string.Format("{0}", (char)((int)'A' + maxIndex));
        }
    }
}
