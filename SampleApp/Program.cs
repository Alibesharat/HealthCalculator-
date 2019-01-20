using HealthCalculator;
using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fitness f = new Fitness();

            var val = f.BMR(102, 80, ActivityStatuse.Hyperactive);
            Console.WriteLine($"the BMR Result Is {val} ");
            Console.ReadLine();
        }
    }
}
