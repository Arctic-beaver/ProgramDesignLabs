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


		public Lab3Console(double[] X, double[] Y, double Xt)
        {
			xt = Xt;
			enteredX = X;
			enteredY = Y;
			amountOfElements = Math.Min(X.Length, Y.Length);
			TableOfDifferences = new double[amountOfElements, amountOfElements];
		}

		public void DoLab3()
        {
			FillTableOffDifferences();

        }

		void FillTableOffDifferences()
        {
            for (int i = 0; i < amountOfElements; i++)
            {
                TableOfDifferences[0, i] = enteredY[i];
            }

			for (int down = 1; down < amountOfElements; down++)
            {
				for (int left = 1; left < amountOfElements; left++)
                {
					TableOfDifferences[left, down] = TableOfDifferences[left - 1, down] - TableOfDifferences[left - 1, down - 1];
                }
            }
        }
	}
}
