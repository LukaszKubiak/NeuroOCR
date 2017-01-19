using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkOCR
{
    public partial class MainForm : Form
    {
        private Receptors receptors = new Receptors();
        public Bitmap image { get; set; }
        System.Drawing.Graphics formGraphics;

        public MainForm()
        {
            InitializeComponent();
            formGraphics = this.CreateGraphics();
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
    }
}
