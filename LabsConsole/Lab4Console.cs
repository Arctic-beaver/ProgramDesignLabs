using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole
{
    public class Lab4Console
    {
        double[] enteredX;
        double[] enteredY;
        double[,] degrees;
        double[] pr; //xi * yi

        public Lab4Console(double[] X, double[] Y)
        {
            enteredX = X;
            enteredY = Y;
            degrees = new double[20,9];
            pr = new double[20];
        }

        void smth()
        {
            //заполнили степени x и произведения yx
            for (int i = 0; i < 20; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    degrees[i, j] = Math.Pow(enteredX[i], j);
                }

                pr[i] = enteredX[i] * enteredY[i];
            }
        }

    }
}
