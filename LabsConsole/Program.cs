
using LabsConsole;


Lab1Console lab1 = new Lab1Console(15, 200, 0.95, 10, 0.005, 0.001, 3, 0.01, 0.01, 0.001); //в-т 19

lab1.DoLab1();

Lab2Console lab2 = new Lab2Console(new double[]{ 1.45, 1.36, 1.14 }, 
                             new double[]{ 3.14, 4.15, 5.65 });

lab2.DoLab2();

Lab3Console lab3 = new Lab3Console(new double[] { 3.50, 4.55, 5.60, 6.20, 7.75, 8.80, 9.45, 10.95 },
    new double[] { 33.1154, 34.8133, 36.5982, 38.4747, 40.4473, 42.5211, 44.7012, 46.9931 }, 7.213);

lab3.DoLab3();

Lab4Console lab4 = new Lab4Console(
    new double[] { 0.1 , 0.3 , 0.5 , 0.7 , 0.9 , 1.1 , 1.3 , 1.5 , 1.7 , 1.9 , 2.1 ,
    2.3 , 2.5 , 2.7 , 2.9 , 3.1 , 3.3 , 3.5 , 3.7 , 3.9 }, 
    new double[] { 0.00 , 0.09 , 0.26 , 0.20 , 0.29 , 0.14 , 0.26 , 0.45 , 0.43 ,
        0.71 , 0.70 , 1.00 , 1.01 , 1.17 , 1.39 , 1.22 , 1.43 , 1.81 , 1.84, 1.99 });
