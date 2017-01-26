using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class layer
    {
        public int size { get; set; }
        public perceptron Perceptron { get; set; }
        public Matrix<double> values { get; set; }
        List<object> result;

        public layer(int n, int m)
        {
            this.size = m;
            Perceptron = new perceptron(perceptron.sigmoid, n, m);
            values = Matrix<double>.Build.Dense(1, m);
        }

    }
}
