// Lab_05_2_UT.cs
// Якубовський Владислав
// Unit-тест до програми Lab_05_2.cs
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AP_Lab_05_2;

namespace AP_Lab_05_2_UT
{
    [TestClass]
    public class Lab_05_2_UT
    {
        [TestMethod]
        public void TestSummarize()
        {
            int n = 1;

            double k = Lab_05_2.Summarize(0.5, 0.001, ref n);

            Assert.AreEqual(k, Math.Log(1.5), 0.001);
        }
    }
}
