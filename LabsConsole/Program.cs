
using LabsConsole;


Lab1Console lab1 = new Lab1Console(15, 200, 0.95, 10, 0.005, 0.001, 3, 0.01, 0.01, 0.001); //в-т 19

//lab1.DoLab1();

Lab2Console lab2 = new Lab2Console(new List<double> { 1.45, 1.36, 1.14}, 
                                    new List<double> { 3.14, 4.15, 5.65 });

lab2.DoLab2();
