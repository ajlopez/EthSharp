namespace EthSharp.Tests.Vm
{
    using System;
    using EthSharp.Vm;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
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
    }
}
