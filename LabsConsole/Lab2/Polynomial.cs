using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole.Lab2
{
    public class Polynomial
    {
		double[] coefficients;
		int filledLen;

		public Polynomial()
		{
			coefficients = new double[10];
			filledLen = 0;
		}
		public Polynomial(double[] coefs)
		{
			coefficients = new double[10];
			filledLen = 0;
			for (int i = 0; i < coefs.Length; i++)
            {
				coefficients[i] = coefs[i];
            }
		}

		public override string ToString()
        {
			string result = string.Empty;
			for (int i = Count(); i > 0; i--)
            {
				result = $"{Math.Round(coefficients[i], 4)}*x^{Count() - i} + {result}";
            }

            return result;
        }

        public int Count()
        {
			return filledLen;
		}

		public static Polynomial SummPolynomial(Polynomial a, Polynomial b)
		{
			Polynomial result = new Polynomial();

			int idxMax = Math.Max(a.Count(), b.Count());

			for (int i = idxMax, ai = a.Count(), bi = b.Count(); i > 0; i--, ai--, bi--)
            {
				if (ai > 0 && bi > 0)
                {
					result.coefficients[i] = a.coefficients[ai] + b.coefficients[ai];
				}
				else if (ai > 0)
                {
					result.coefficients[i] = a.coefficients[ai];
				}
				else if (bi > 0)
				{
					result.coefficients[i] = b.coefficients[bi];
				}
			}

			return result;
		}

		public static Polynomial MultiplyPolynomial(Polynomial a, Polynomial b)
		{
			Polynomial result = new Polynomial();
			
			if (a.Count() == 0)
            {
				return b;
            }
			if (b.Count() == 0)
			{
				return a;
			}

			for (int i = 0; i < a.Count(); i++)
            {
				var tmp = MultiplyPolynomialAndValue(b, a.coefficients[i]);
				result = SummPolynomial(tmp, result);
			}
			return result;
		}

		public static Polynomial MultiplyPolynomialAndValue(Polynomial a, double k)
		{
			Polynomial result = new Polynomial();

			for (int i = 0; i < a.Count(); i ++)
            {
				result.coefficients[i] = a.coefficients[i] * k;
            }

			return result;
		}
	}
}
