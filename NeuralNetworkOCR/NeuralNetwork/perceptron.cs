using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class perceptron
    {
        trainingData t1;
        public Matrix<double> W { get; set; }

        public delegate double funkcja(double x, bool deriv);

        public funkcja act_f;
        public perceptron(funkcja f1, int n, int m)
        {
            Random generator = new Random();
            act_f = f1;
            if (n != 0)
            {
                W = Matrix<double>.Build.Dense(n, m);
                for (int i = 0; i < W.RowCount; i++)
                {
                    for (int j = 0; j < W.ColumnCount; j++)
                    {
                        W[i, j] = generator.NextDouble() * (10) - 5;
                    }
                }
            }

        }
        /// <summary>
        /// Funkcja aktywacyjna - sigmoidalna
        /// </summary>
        /// <param name="x">Element wektora/macierzy</param>
        /// <returns>Wynik funkcji aktywacji</returns>
        public static double sigmoid(double x, bool deriv = false)
        {
            if (deriv)
                return x * (1 - x);
            return 1 / (1 + Math.Pow(Math.E, x));
        }


    }
}
