using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole
{
    public class Lab2Console
    {
		//Интерполирование и экстраполирование данных.
		//Интерполяционный многочлен Лагранжа

		//В-т 19

		List<double> enteredX;
		List<double> enteredY;
		List<double> coefficients;
		List<double> diagCoef;

		private int amountOfValues; //размер многочлена равен amountOfValues - 1

		public double[,] matrixCoef { get; set; }

		public Lab2Console(List<double> x, List<double> y)
        {
			enteredX = x;
			enteredY = y;
			diagCoef = new List<double>();

			amountOfValues = Math.Min(enteredY.Count, enteredX.Count);

			coefficients = new List<double>();
			matrixCoef = new double[x.Count, x.Count];
		}

		public void FillMatrix(List<double> x)
		{
			for (int i = 0; i < amountOfValues; i++)
            {
				for (int j = 0; j < amountOfValues; i++)
                {
					if (i == j)
					{
						matrixCoef[i, j] = -enteredX[i]; //это диагональ
						diagCoef[i] = -enteredX[i];
					}
					else
					{
						matrixCoef[i, j] = enteredX[i] - enteredX[j];
					}
                }
            }
		}

		public void FindCoefficients()
        {
			for (int i = 0; i < amountOfValues; i++)
			{
				
			}
		}



    }
}


