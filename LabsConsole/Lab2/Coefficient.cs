using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole
{
    public class Coefficient
    {
        public double Denominator { get; set; } //Знаменатель
        public List<double> NumeratorPolinom { get; set; } //Числитель в виде a0 = num[0], a1 = num[1]...

        public Coefficient(List<double> x)
        {
            Denominator = new double();
            NumeratorPolinom = new List<double>();        

            CountDenominator(x);
            CountNumerator(x);
        }

        public void CountDenominator(List<double> x)
        {

        }

        public void CountNumerator(List<double> x)
        {

        }
    }
}
