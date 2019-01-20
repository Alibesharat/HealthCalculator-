using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HealthCalculator.test
{
    [TestClass]
    public class FitnessTest
    {
        Fitness fitness = new Fitness();
        [TestMethod]
        public void BMITest()
        {
          
            var result = fitness.BMI(192, 92);
            Assert.AreEqual(24.96, Math.Round(result.Item1,2));
        }


       
    }
}
