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

		public void DoLab2()
        {
			FillMatrix();
			FindCoefficients();
			Polynomial resultPolynomial = CreateResultPolynomial();
            Console.WriteLine("Ваш полином: ");
            Console.WriteLine(resultPolynomial.ToString());
		}

		private void FillMatrix()
		{
			for (int i = 0; i < amountOfValues; i++)
            {
				for (int j = 0; j < amountOfValues; j++)
                {
					if (i == j)
					{
						matrixCoef[i, j] = -enteredX[i]; //это диагональ
						diagPolynomial.Add( new Polynomial(new double[] {1, -enteredX[i] }));
					}
					else
					{
						matrixCoef[i, j] = enteredX[i] - enteredX[j];
					}
                }
            }
		}

		private void FindCoefficients()
        {
			for (int i = 0; i < amountOfValues; i++)  //коэффициентов будет столько же, сколько и строк в матрице
			{
				var coefficient = new Coefficient();
				Polynomial tmp = new Polynomial();
				
				//найдём числитель коэффициента 

				for (int j = 0; j < diagPolynomial.Count; j++)
                {
					if (i != j) tmp = Polynomial.MultiplyPolynomial(tmp, diagPolynomial[j]);
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
				coefficients.Add(coefficient);
			}
		}

		private Polynomial CreateResultPolynomial()
        {
			//здесь нам нужен лист коэффициентов и значения y
			//домножим каждый коэффициент на соответствующий y

			//+ найдём на что нужно домножать все коэффициенты
			double NOK = 1;
			for (int i = 0; i < amountOfValues; i++)
            {
				coefficients[i].NumeratorPolinom = Polynomial
					.MultiplyPolynomialAndValue(coefficients[i].NumeratorPolinom, enteredY[i]);
				NOK = MathHelper.Nok(coefficients[i].Denominator, NOK);
			}

			//домножим все коэффициенты на нок, получим сумму полиномов, просуммируем
			Polynomial resultPolynomial = new Polynomial();
			for (int i = 0; i < amountOfValues; i++)
			{
				double value = NOK / coefficients[i].Denominator;
				coefficients[i].NumeratorPolinom = Polynomial
					.MultiplyPolynomialAndValue(coefficients[i].NumeratorPolinom, value);
				resultPolynomial = Polynomial.SummPolynomial(resultPolynomial, coefficients[i].NumeratorPolinom);
			}

			return resultPolynomial;
		}

    }
}


