using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLogic
{
    public class Lab1
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

		public Lab1(double s, double v, double p, double a, double c, double ds, double Dv, double dp, double da, double dc)
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
			df =  dC + dA + dP + 2 * dV + dS;
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

        }


	int main()
	{
		int flag = 0; 

		float c, bc, a, ba, p, bp, v, Dv, s, bs;

		float F, bF, DF;
		cin >> c >> bc >> a >> ba >> p >> bp >> v >> Dv >> s >> bs;

		float bv = RelativeError(v, Dv); //находим относительную погрешность для S

		bF = ConcreteRelativeError(bc, ba, bp, bv, bs); //нашли относительную погрешность для F

		cout << "Относительная погрешность v: " << bv << "\n";
		cout << "Относительная погрешность для F: " << bF << "\n";
		if (bF < 0.1)
		{
			cout << "Берем 2 - 3 значащие цифры" << "\n";
			flag = 1; // сокращаем до 2-3знаков

		}
		else cout << " Округляем до целой части ";
		F = result_F(c, a, p, v, s);
		cout << "Результат F = " << F << "\n";
		DF = F * bF;
		cout << "Результат DF = " << DF << "\n";

		int dlina_f = dlina(F);
		int dlina_Df = dlina(DF);

		if (flag = 1)
		{
			cout << "ответ округляем до 2 знаков\n";
			cout << "F = " << round(F / pow(10, dlina_f - 2)) / 10 << "*10^" << dlina_f - 1 << "\n";
			cout << "дельта(F∗) = " << round(DF / pow(10, dlina_Df - 2)) / 10 << "*10^" << dlina_Df - 1 << "\n";
			cout << "бета(F∗) = " << round(bF * 1000) / 10 << "%\n";
		}

		_getch();
		return 0;
	}



}
}
