using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole.Lab2
{
    public class Polynomial
    {
		List<double> coefficients;

		public Polynomial(List<double> givenCoefficients)
        {
			coefficients = givenCoefficients;
        }

		public Polynomial()
		{
			coefficients = new List<double>();
		}

		public int Count()
        {
			return coefficients.Count;
		}

		public Polynomial SummPolynomial(Polynomial a, Polynomial b)
		{
			Polynomial result = new Polynomial(new List<double>());

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

		public Polynomial MultiplyPolynomial(Polynomial a, Polynomial b)
		{
			Polynomial result = new Polynomial(new List<double>());

			for (int i = 0; i < a.Count(); i++)
            {
				Polynomial tmp = new Polynomial(new List<double>());
				tmp = MultiplyPolynomialAndValue(b, a.coefficients[i]);
				result = SummPolynomial(tmp, result);
			}
			return result;
		}

		public Polynomial MultiplyPolynomialAndValue(Polynomial a, double k)
		{
			Polynomial result = new Polynomial(new List<double>());

			for (int i = 0; i < a.Count(); i ++)
            {
				result.coefficients[i] = a.coefficients[i] * k;
            }

			return result;
		}
	}
}
