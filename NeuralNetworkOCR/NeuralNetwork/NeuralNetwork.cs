using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class neuralNetwork
    {
        List<trainingData> t1 = new List<trainingData>();
        List<layer> layers;
        int in_size;
        int out_size;

        public neuralNetwork(int n, int m)
        {
            in_size = n;
            out_size = m;
            layers = new List<layer>();
            layers.Add(new layer(0, n));
            layers.Add(new layer(n, m));

        }

        /// <summary>
        /// Dodawanie nowej warstwy
        /// </summary>
        /// <param name="n">Rozmiar nowej warstwy</param>
        public void appendLayer(int n)
        {
            List<layer> new_layers = layers;
            layers = new List<layer>();
            int last = 0;
            for (int i = 0; i < new_layers.Count - 1; i++)
            {
                layers.Add(new_layers[i]);
                last = new_layers[i].size;
            }
            layers.Add(new layer(last, n));
            layers.Add(new layer(n, out_size));
        }
        /// <summary>
        /// Użycie funkcji aktywacji na każdym elemencie macierzy
        /// </summary>
        /// <param name="p1">perceptron</param>
        /// <param name="input">macierz wejściowa</param>
        /// <returns></returns>
        public Matrix<double> execAct_f(perceptron p1, Matrix<double> input, bool deriv = false)
        {
            for (int first = 0; first < input.RowCount; first++)
            {
                for (int second = 0; second < input.ColumnCount; second++)
                {
                    input[first, second] = p1.act_f(input[first, second], deriv);
                }
            }
            return input;
        }
        /// <summary>
        /// Metoda propagacji - sporządza predykcję wektora wejściowego
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Matrix<double> propagate(trainingData data)
        {
            var vec = Matrix<double>.Build.DenseOfRowVectors(data.input);
            layers[0].values = vec;
            for (int i = 1; i < layers.Count; i++)
            {
                vec = vec * layers[i].Perceptron.W;
                vec = execAct_f(layers[i].Perceptron, vec);
                layers[i].values = vec;
            }
            return vec;
        }
        /// <summary>
        /// Obliczanie mnożenia macierzy * wektor
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>Macierz wynikowa</returns>
        public Matrix<double> calculateVectorProduct(Matrix<double> A, Matrix<double> B)
        {
            if (A.ColumnCount == B.ColumnCount)
            {
                Matrix<double> C = Matrix<double>.Build.Dense(1, A.ColumnCount);
                for (int i = 0; i < A.ColumnCount; i++)
                {
                    C[0, i] = A[0, i] * B[0, i];
                }
                return C;
            }
            Matrix<double> D = Matrix<double>.Build.Dense(A.RowCount, A.ColumnCount);
            return D;

        }
        /// <summary>
        /// Obliczanie mnożenia macierzy - odpowiednik operatora * w Pythonie
        /// </summary>
        /// <param name="A">Pierwsza macierz</param>
        /// <param name="B">Druga macierz</param>
        /// <returns>Macierz wynikowa</returns>
        public Matrix<double> calculateMatrixProduct(Matrix<double> A, Matrix<double> B)
        {
            if (A.RowCount == B.ColumnCount)
            {
                Matrix<double> C = Matrix<double>.Build.Dense(B.RowCount, A.ColumnCount);
                for (int i = 0; i < B.RowCount; i++)
                {
                    if (B.ColumnCount == 1)
                    {
                        for (int j = 0; j < A.ColumnCount; j++)
                        {
                            C[i, j] = A[0, j] * B[i, 0];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < A.ColumnCount; j++)
                        {
                            C[i, j] = A[0, j] * B[i, j];
                        }
                    }
                }
                return C;
            }
            Matrix<double> D = Matrix<double>.Build.Dense(A.RowCount, A.ColumnCount);
            return D;

        }
        /// <summary>
        /// Obliczanie błędu
        /// </summary>
        /// <param name="v">Dane treningowe</param>
        /// <returns></returns>
        public Matrix<double> calculate_error(trainingData v)
        {
            var y = Matrix<double>.Build.DenseOfRowVectors(v.output);
            var ysim = propagate(v);
            return y.Subtract(ysim);

        }
        /// <summary>
        /// Propagacja wsteczna
        /// </summary>
        /// <param name="v">Dane treningowe</param>
        public void back_propagate(trainingData v)
        {
            var error = calculate_error(v);
            int numberOfLayers = layers.Count - 1;
            for (int index = 0; index < numberOfLayers; index++)
            {
                var valuesActivationFunction = execAct_f(layers[numberOfLayers - index].Perceptron, layers[numberOfLayers - index].values, true);
                var delta = calculateVectorProduct(error, valuesActivationFunction);

                var scalesMatrixTransposition = layers[numberOfLayers - index].Perceptron.W.Transpose();
                error = delta * scalesMatrixTransposition;
                var matrixMultiplied = calculateMatrixProduct(layers[numberOfLayers - index - 1].values, delta.Transpose());
                var matrixTransposed = matrixMultiplied.Transpose();
                layers[numberOfLayers - index].Perceptron.W = layers[numberOfLayers - index].Perceptron.W.Subtract(matrixTransposed);
            }

        }

    }
}
