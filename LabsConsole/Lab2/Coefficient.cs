using LabsConsole.Lab2;
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
        public Polynomial NumeratorPolinom { get; set; } //Числитель

        public Coefficient()
        {
            Denominator = new double();
            NumeratorPolinom = new Polynomial();        
        }
    }
}
