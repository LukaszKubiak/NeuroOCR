using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class trainingData
    {
        public Vector<double> input { get; set; }
        public Vector<double> output { get; set; }

        public trainingData(double[] input, double[] output)
        {
            this.input = Vector<double>.Build.DenseOfArray(input);
            if (output.Length != 0)
                this.output = Vector<double>.Build.DenseOfArray(output);
            else
                this.output = Vector<double>.Build.Dense(1);
        }

    }
}
