using HealthCalculator;
using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BMI b = new BMI(209, 65);
           var (val,message)= b.Calc();
            Console.WriteLine($"the BMI Result Is {val} - - {message}");
            Console.ReadLine();
        }
    }
}
