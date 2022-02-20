using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsConsole
{
    public static class MathHelper
    {
        public static double Nod(double a, double b)
        {
            if (b < 0)
                b = -b;
            if (a < 0)
                a = -a;
            while (b > 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static double Nok(double a, double b)
        {
            return Math.Abs(a * b) / Nod(a, b);
        }
    }
}
