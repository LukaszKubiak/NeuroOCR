using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkOCR
{
    class Receptor
    {
        public int  x1 { get; set; }
        public int  y1 { get; set; }
        public int  x2 { get; set; }
        public int  y2 { get; set; }
        public int  left { get; set; }
        public int  right { get; set; }
        public int  top { get; set; }
        public int  bottom { get; set; }
        public float k { get; set; }
        public float z { get; set; }
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }
        public float d { get; set; }
        public Receptor(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;

            left = Math.Min(x1, x2);
            right = Math.Max(x1, x2);
            top = Math.Min(y1, y2);
            bottom = Math.Max(y1, y2);

            if (x1 != x2)
            {
                k = (float)(y2 - y1) / (float)(x2 - x1);
                z = (float)y1 - k * x1;

                a = y1 - y2;
                b = x2 - x1;
                c = y1 * (x1 - x2) + x1 * (y2 - y1);
                d = (float)Math.Sqrt(a * a + b * b);
            }
        }

        public bool receptorState(int x, int y)
        {
            if ((x < left) || (y < top) || (x > right) || (y > bottom))
                return false;
            else if ((x1 == x2) || (y1 == y2))
                return true;
            else if (Math.Abs(a * x + b * y + c) / d < 1)
                return true;
            return false;
        }
    }
}
