
namespace LabsConsole
{
    public class Lab2Console
    {
        double[] enteredX;
        double[] enteredY;
        double[] L;
        int amountOfElements;

        public Lab2Console(double[] x, double[] y)
        {
            enteredX = x;
            enteredY = y;
            amountOfElements = Math.Min(x.Length, y.Length);
            L = new double[amountOfElements];
        }

        public void DoLab2()
        {
            Algorithm();
            WritePolynomial();
        }
        public void WritePolynomial()
        {
            string result = string.Empty;

            for (int i = amountOfElements - 1; i > 0; i--)
            {
                if (L[i] != 0)
                {
                    var num = Math.Round(L[i], 3);
                    if (num >= 0)
                    {
                        if (i != 0) result += " + ";
                    }
                    else result += " - ";
                    result += $"{Math.Abs(num)} * x^{amountOfElements - i}";
                }
            }
            Console.WriteLine("Ваш полином: ");
            Console.WriteLine(result);
        }

        private void Algorithm()
        {
            for (int k = 0; k < amountOfElements; k++)
            {
                double[] A = new double[amountOfElements];
                A[0] = 1;
                for (int j = 0; j < amountOfElements; j++)
                {
                    if (j != k)
                    {
                        A = Mul(GetPolynomial(k, j), A);
                    }
                }
                L = Summ(L, MulPolynomialAndValue(A, enteredY[k]));
            }
        }

        private double[] Summ(double[] polynomial, double[] secPolynomial)
        {
            double[] result = new double[amountOfElements];
            for (int i = 0; i < amountOfElements; i++)
            {
                result[i] = polynomial[i] + secPolynomial[i];
            }
            return result;
        }

        private double[] MulPolynomialAndValue(double[] polynomial, double value)
        {
            double[] result = new double[amountOfElements];
            for (int i = 0; i < amountOfElements; i++)
            {
                result[i] = polynomial[i] * value;
            }
            return result;
        }

        private double[] GetPolynomial(int k, int j)
        {
            var denominator = enteredX[k] - enteredX[j];
            var kx1 = (1 / denominator);
            var kx0 = (enteredX[j] / denominator);

            return new double[]{ kx0, kx1 };
        }

        private double[] Mul(double[] polynomial, double[] A)
        {
            double[] result = new double[amountOfElements];

            for (int i = 0; i < amountOfElements; i++)
            {
                for (int j = 0; j < amountOfElements; j++)
                {
                    if (j + 1 == i)
                    {
                        result[i] += polynomial[1] * A[j];
                    }
                    else if (j == i)
                    {
                        result[i] += polynomial[0] * A[j];
                    }
                }
            }
            return result;
        }
    }
}
