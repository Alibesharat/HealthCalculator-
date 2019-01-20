using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HealthCalculator.test
{
    [TestClass]
    public class FitnessTest
    {
        [TestMethod]
        public void BMITest()
        {
            Fitness f = new Fitness();
            var result = f.BMI(192, 92);
            Assert.AreEqual(24.96, Math.Round(result.Item1,2));
        }
    }
}
