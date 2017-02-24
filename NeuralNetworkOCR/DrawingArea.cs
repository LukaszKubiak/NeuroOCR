using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;

namespace NeuralNetworkOCR
{
    public partial class DrawingArea : UserControl
    {
        private Bitmap image;
        private bool showReceptors = false;
        private bool scaleImage = true;
        private Receptors receptors = null;

        private Shrink shrinkFilter = new Shrink(Color.FromArgb(255, 255, 255));
        private ResizeNearestNeighbor resizeFilter;

        private bool tracking = false;

        [DefaultValue(false)]
        public bool ShowReceptors
        {
            get { return showReceptors; }
            set
            {
                showReceptors = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        public bool ScaleImage
        {
            get { return scaleImage; }
            set { scaleImage = value; }
        }

        [Browsable(false)]
        public Receptors Receptors
        {
            get { return receptors; }
            set
            {
                receptors = value;
                Invalidate();
            }
        }

        public Size AreaSize
        {
            get { return new Size(ClientRectangle.Width - 2, ClientRectangle.Height - 2); }
        }

        public DrawingArea()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;

            Pen blackPen = new Pen(Color.Black, 1);
            Pen bluePen = new Pen(Color.Blue, 1);
            Brush whiteBrush = new SolidBrush(Color.White);

            g.DrawRectangle(blackPen, 0, 0, rc.Width - 1, rc.Height - 1);
            g.FillRectangle(whiteBrush, 1, 1, rc.Width - 2, rc.Height - 2);
            if (image != null)
            {
                g.DrawImage(image, 1, 1, image.Width, image.Height);
            }
            if ((showReceptors) && (receptors != null))
            {
                foreach (Receptor r in receptors)
                {
                    g.DrawLine(bluePen,
                        r.x1 + 1, r.y1 + 1,
                        r.x2 + 1, r.y2 + 1);
                }
            }

            blackPen.Dispose();
            bluePen.Dispose();
            whiteBrush.Dispose();

            base.OnPaint(pe);
        }
        public void ClearImage()
        {
            int width = this.ClientRectangle.Width - 2;
            int height = this.ClientRectangle.Height - 2;
            Brush whiteBrush = new SolidBrush(Color.White);

            if (image != null)
                image.Dispose();
            image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(whiteBrush, 0, 0, width, height);

            g.Dispose();
            whiteBrush.Dispose();

            Invalidate();
        }

        public void DrawLetter(char c, string fontName, float size, bool italic)
        {
            DrawLetter(c, fontName, size, italic, true);
        }
        public void DrawLetter(char c, string fontName, float size, bool italic, bool invalidate)
        {
            int width = this.ClientRectangle.Width - 2;
            int height = this.ClientRectangle.Height - 2;
            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            if (image != null)
                image.Dispose();

            image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(image);

            g.FillRectangle(whiteBrush, 0, 0, width, height);

            string str = new string(c, 1);
            Font font = new Font(fontName, size, (italic) ? FontStyle.Italic : FontStyle.Regular);
            g.DrawString(str, font, blackBrush, new Rectangle(0, 0, width, height));

            g.Dispose();
            font.Dispose();
            blackBrush.Dispose();
            whiteBrush.Dispose();

            if (invalidate)
                Invalidate();
        }
        public Bitmap GetImage()
        {
            return GetImage(true);
        }
        public Bitmap GetImage(bool invalidate)
        {
            if (image == null)
                ClearImage();

            if (scaleImage)
            {
                Bitmap tempImage = shrinkFilter.Apply(image);

                int width = image.Width;
                int height = image.Height;
                int tw = tempImage.Width;
                int th = tempImage.Height;
                float fx = (float)width / (float)tw;
                float fy = (float)height / (float)th;

                if (fx > fy)
                    fx = fy;
                int nw = (int)Math.Round(fx * tw);
                int nh = (int)Math.Round(fy * th);
                resizeFilter = new ResizeNearestNeighbor(nw, nh);
                Bitmap tempImage2 = resizeFilter.Apply(tempImage);
                Brush whiteBrush = new SolidBrush(Color.White);
                Graphics g = Graphics.FromImage(image);

                g.FillRectangle(whiteBrush, 0, 0, width, height);

                int x = 0;
                int y = 0;

                if (nw > nh)
                {
                    y = (height - nh) / 2;
                }
                else
                {
                    x = (width - nw) / 2;
                }

                g.DrawImage(tempImage2, x, y, nw, nh);

                g.Dispose();
                whiteBrush.Dispose();
                tempImage.Dispose();
                tempImage2.Dispose();
            }
            if (invalidate)
                Invalidate();

            return image;
        }

        private void DrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if ((!tracking) && (e.Button == MouseButtons.Left))
            {
                Capture = true;
                tracking = true;
                if (image == null)
                    ClearImage();
            }
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (tracking)
            {
                int x = e.X - 1;
                int y = e.Y - 1;

                if ((x > 0) && (y > 0) && (x < image.Width) && (y < image.Height))
                {
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        Graphics g = Graphics.FromImage(image);
                        g.FillEllipse(brush, x - 5, y - 5, 11, 11);
                        g.Dispose();
                    }
                    Invalidate();
                }
            }
        }

        private void DrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if ((tracking) && (e.Button == MouseButtons.Left))
            {
                Capture = false;
                tracking = false;
            }
        }
    }
}
