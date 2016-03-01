namespace EthSharp.Tests.Vm
{
    using System;
    using System.Numerics;
    using EthSharp.Vm;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataWordTests
    {
        [TestMethod]
        public void CreateDataWordUsingPositiveInteger()
        {
            var dw = new DataWord(1);

            var result = dw.Data;

            Assert.IsNotNull(result);
            Assert.AreEqual(32, result.Length);

            for (int k = 0; k < 31; k++)
                Assert.AreEqual(0x00, result[k]);

            Assert.AreEqual(0x01, result[31]);
        }

        [TestMethod]
        public void GetSmallIntegerAsBigInteger()
        {
            var dw = new DataWord(1);

            var result = dw.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(BigInteger.One, result);
        }

        [TestMethod]
        public void AddOneToOne()
        {
            var dw = new DataWord(1);

            var result = dw.Add(dw).Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(new BigInteger(2), result);
        }
    }
}
