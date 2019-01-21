using HealthCalculator;
using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fitness f = new Fitness();

            var BMIResult = f.BMI(192, 92);
            Console.WriteLine($"the BMI result is : {Math.Round(BMIResult.Item1,2)}  ");
            var BMRResult = f.BMR(165,60, 30,false,ActivityStatuse.none);
            Console.WriteLine($"the BMRResult result is :{BMRResult}  ");
            var BMRResult4 = f.IBW(152.4, true);
            Console.WriteLine($"the BMRResult result is :{BMRResult}  ");
            Console.ReadLine();
        }
    }
}
