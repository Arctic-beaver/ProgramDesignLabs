using LabsConsole.Lab2;
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
		List<Coefficient> coefficients;
		List<Polynomial> diagPolynomial;

		private int amountOfValues; //размер многочлена равен amountOfValues - 1

		public double[,] matrixCoef { get; set; }

		public Lab2Console(List<double> x, List<double> y)
        {
			enteredX = x;
			enteredY = y;
			diagPolynomial = new List<Polynomial>();

			amountOfValues = Math.Min(enteredY.Count, enteredX.Count);

			coefficients = new List<Coefficient>();
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
						diagPolynomial[i] = new Polynomial(new List<double> { 1, -enteredX[i] });
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
			for (int i = 0; i < amountOfValues; i++)  //коэффициентов будет столько же, сколько и строк в матрице
			{
				var coefficient = new Coefficient();
				Polynomial tmp = new Polynomial();
				
				//найдём числитель коэффициента 

				for (int j = 0; j < diagPolynomial.Count; j++)
                {
					if (i != j) tmp = tmp.MultiplyPolynomial(tmp, diagPolynomial[j]);
                }

				coefficient.NumeratorPolinom = tmp;

				//найдём знаменатель коэффициента

				double multipledDenominator = 1;

				for (int j = 0; j < amountOfValues; j++)
                {
					if (i != j) multipledDenominator *= matrixCoef[i, j]; 
				}

				coefficient.Denominator = multipledDenominator;

				//занесём коэффициент в список
				coefficients[i] = coefficient;
			}
		}



    }
}


