using HealthCalculator;
using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fitness f = new Fitness();

            var val = f.BMI(192, 92);
            Console.WriteLine($"the result is : {Math.Round(val.Item1,2)}  ");
            Console.ReadLine();
        }
    }
}
