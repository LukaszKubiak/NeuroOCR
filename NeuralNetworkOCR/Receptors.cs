using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkOCR
{
    class Receptors : CollectionBase
    {
        private Random  rand;
        public Size     size { get; set; }

        public Receptors()
        {
            rand = new Random();
            size = new Size(100,100);
        }

        public Receptor this[int index]
        {
            get { return ((Receptor)InnerList[index]); }
        }

        public void Add(Receptor receptor)
        {
            InnerList.Add(receptor);
        }

        public void Generate(int count)
        {
            int maxX = size.Width;
            int maxY = size.Height;
            int i = 0;

            while (i < count)
            {
                int x1 = rand.Next(maxX);
                int y1 = rand.Next(maxY);
                int x2 = rand.Next(maxX);
                int y2 = rand.Next(maxY);

                int dx = x1 - x2;
                int dy = y1 - y2;
                int length = (int)Math.Sqrt(dx * dx + dy * dy);

                if ((length < 10) || (length > 50))
                    continue;

                InnerList.Add(new Receptor(x1, y1, x2, y2));
                i++;
            }
        }

        public int[] GetReceptorsState(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            int n = InnerList.Count;
            int[] state = new int[n];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (image.GetPixel(x, y).R == 0)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (state[i] == 1)
                                continue;

                            if (((Receptor)InnerList[i]).receptorState(x, y))
                                state[i] = 1;
                        }
                    }
                }
            }

            return state;
        }
    }
}
