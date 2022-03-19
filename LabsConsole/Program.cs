
using LabsConsole;


Lab1Console lab1 = new Lab1Console(15, 200, 0.95, 10, 0.005, 0.001, 3, 0.01, 0.01, 0.001); //в-т 19

//lab1.DoLab1();

Lab2Console lab2 = new Lab2Console(new double[]{ 1.45, 1.36, 1.14 }, 
                             new double[]{ 3.14, 4.15, 5.65 });

//lab2.DoLab2();

Lab3Console lab3 = new Lab3Console(new double[] { 3.50, 4.55, 5.60, 6.20, 7.75, 8.80, 9.45, 10.95 },
    new double[] { 33.1154, 34.8133, 36.5982, 38.4747, 40.4473, 42.5211, 44.7012, 46.9931 }, 7.213);

lab3.DoLab3();

