
using LabsConsole;


Lab1Console lab1 = new Lab1Console(15, 200, 0.95, 10, 0.005, 0.001, 3, 0.01, 0.01, 0.001); //в-т 19

//lab1.DoLab1();

Lab2Console lab2 = new Lab2Console(new double[]{ 1.45, 1.36, 1.14 }, 
                             new double[]{ 3.14, 4.15, 5.65 });

//lab2.DoLab2();

Lab3Console lab3 = new Lab3Console(new double[] { 1.01, 1.08, 1.11, 1.21, 1.26, 1.33, 1.46, 1.51 },
    new double[] { 12.6183, 12.7644, 12.9122, 13.0617, 13.2130, 13.3660, 13.5207, 13.8357 }, 1.488);

lab3.DoLab3();