using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole
{
	public class Lab3Console
	{
		double xt;
		double[] enteredX;
		double[] enteredY;
		double[,] TableOfDifferences;
        int amountOfElements;
		double[] coefficients;

		public Lab3Console(double[] X, double[] Y, double Xt)
        {
			xt = Xt;
			enteredX = X;
			enteredY = Y;
			amountOfElements = Math.Min(X.Length, Y.Length);
			TableOfDifferences = new double[amountOfElements, amountOfElements];
			coefficients = new double[amountOfElements];
		}

		public void DoLab3()
        {
			FillTableOffDifferences();
			CountCoefficients();
			WritePolynomial();
			Console.WriteLine($"f({xt}) = {Math.Round(FindYt(), 3)}");
        }

		private void WritePolynomial()
		{
			string result = string.Empty;

			for (int i =0; i < amountOfElements; i++)
			{
				if (coefficients[i] != 0)
				{
					var num = Math.Round(coefficients[i], 3);
					if (num >= 0)
					{
						if (i != 0) result += " + ";
					}
					else result += " - ";
					result += $"{Math.Abs(num)} * x^{i}";
				}
			}
			Console.WriteLine("Ваш полином: ");
			Console.WriteLine(result);
		}

		private double FindYt()
        {
			double yt = 0;
			for (int i = 0; i < amountOfElements; i++)
            {
				yt += Math.Pow(xt, i) * coefficients[i];
            }
			return yt;
        }

		void FillTableOffDifferences()
        {
            for (int i = 0; i < amountOfElements; i++)
            {
                TableOfDifferences[0, i] = enteredY[i];
            }

			for (int left = 1; left < amountOfElements; left++)
            {
				for (int down = left; down < amountOfElements; down++)
                {
					TableOfDifferences[left, down] = TableOfDifferences[left - 1, down] - TableOfDifferences[left - 1, down - 1];
                }
            }
        }

		void CountCoefficients()
        {
			coefficients[0] += TableOfDifferences[0, 0];
			for (int i = 1; i < amountOfElements; i++)
            {
				CountPolynomial(i);
            }
        }

		void CountPolynomial(int amountOfBranches)
        {
			double value;
			for (int i = 0; i < amountOfBranches; i++)
			{
				for (int j = i + 1; j < amountOfBranches; j++)
				{
					for (int k = j + 1; k < amountOfBranches; k++)
					{
						for (int l = k + 1; l < amountOfBranches; l++)
						{
							for (int m = l + 1; m < amountOfBranches; m++)
							{
								for (int n = m + 1; n < amountOfBranches; n++)
								{
									for (int o = n + 1; o < amountOfBranches; o++)
									{
										value = enteredX[i] * enteredX[j] * enteredX[k] * enteredX[l] * enteredX[m] * enteredX[n] * enteredX[o] * TableOfDifferences[amountOfBranches, amountOfBranches];
										if (amountOfBranches % 2 == 0) coefficients[0] += value;
										else coefficients[0] -= value;
									}
									value = enteredX[i] * enteredX[j] * enteredX[k] * enteredX[l] * enteredX[m] * enteredX[n] * TableOfDifferences[amountOfBranches, amountOfBranches];
									if (amountOfBranches % 2 == 0) coefficients[1] -= value;
									else coefficients[1] += value;
								}
								value = enteredX[i] * enteredX[j] * enteredX[k] * enteredX[l] * enteredX[m] * TableOfDifferences[amountOfBranches, amountOfBranches];
								if (amountOfBranches % 2 == 0) coefficients[2] += value;
								else coefficients[2] -= value;
							}
							value = enteredX[i] * enteredX[j] * enteredX[k] * enteredX[l] * TableOfDifferences[amountOfBranches, amountOfBranches];
							if (amountOfBranches % 2 == 0) coefficients[3] -= value;
							else coefficients[3] += value;
						}
						value = enteredX[i] * enteredX[j] * enteredX[k] * TableOfDifferences[amountOfBranches, amountOfBranches];
						if (amountOfBranches % 2 == 0) coefficients[4] += value;
						else coefficients[4] -= value;
					}
					value = enteredX[i] * enteredX[j] * TableOfDifferences[amountOfBranches, amountOfBranches];
					if (amountOfBranches % 2 == 0) coefficients[5] -= value;
					else coefficients[5] += value;
				}
				value = enteredX[i] * TableOfDifferences[amountOfBranches, amountOfBranches];
				if (amountOfBranches % 2 == 0) coefficients[6] += value;
				else coefficients[6] -= value;
			}
			coefficients[7] = 1;
		}
	}
}
