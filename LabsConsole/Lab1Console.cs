namespace LabsConsole
{
    public class Lab1Console
    {
        //Лабораторная работа № 1 Определение абсолютной и относительной погрешностей приближенных чисел.
        //Оценка погрешностей результата

        //В-т 19

        private double F; //Величина подъемной силы крыла самолета
        private double S; //Gлощадь проекции крыла на горизонтальную плоскость

        private double V; //Cкорость натекания воздуха на крыло
        private double P; //Плотность атмосферы на заданной высоте
        private double A; //Угол атаки, отсчитываемый от направления нулевой подъемной силы
        private double C; //Коэффициент, зависящий от формы крыла

        //погрешности
        private double dS;
        private double dV;
        private double dP;
        private double dA;
        private double dC;
        private double dF;
        private double DF;

        public Lab1Console(double s, double v, double p, double a, double c, double ds, double Dv, double dp, double da, double dc)
        {
            S = s;
            V = v;
            P = p;
            A = a;
            C = c;
            CountF();
            dS = ds;
            dV = RelativeError(v, Dv);
            dP = dp;
            dA = da;
            dC = dc;
            dF = ConcreteRelativeError();
            DF = Math.Abs(F) * dF; //абсолютная
        }

        private void CountF()
        {
            F = C * A * P * V * V * S;
        }

        //Поиск относительной погрешности для любого числа (Здесь для V)
        private double RelativeError(double a, double Da)
        {
            double ba = Da / Math.Abs(a);
            return Math.Round(ba * 10000) / 10000;
        }

        //Относительная погрешность для F 
        private double ConcreteRelativeError()
        {
            double df;
            df = dC + dA + dP + 2 * dV + dS;
            return Math.Round(df * 10000) / 10000;
        }

        private int Lenght(double value)
        {
            int i = 0;
            while (value > 1)
            {
                i++;
                value /= 10;
            }
            return i;
        }

        public void DoLab1()
        {
            // находим относительную погрешность для S
            // находим относительную и абсолюную погрешность для F и сам F
            // выводим

            Console.WriteLine($" Относительная погрешность для S: {dS}");
            Console.WriteLine($" Относительная погрешность для F: {dF}");

            Console.WriteLine($" F = {C} * {A} * {P} * {V}^2 * {S} = {F}");

            int roundNumber = Lenght(DF) - 2; // это до скольки знаков округляем
            if (roundNumber < 0) roundNumber = 0; // в таком случае округляем до целого

            int degree = Lenght(F) - 1; // степень 10
            F /= Math.Pow(10, degree);
            Math.Round(F, roundNumber);

            int degreeN = Lenght(DF) - 1; // степень 10
            DF /= Math.Pow(10, degreeN);
            Math.Round(DF, roundNumber);
            Console.WriteLine($" Тогда ответ: F = {F} * 10^{degree} +- {DF} * 10^{degree}");
        }
    }
}
