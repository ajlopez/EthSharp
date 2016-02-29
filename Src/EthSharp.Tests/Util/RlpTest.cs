namespace EthSharp.Tests.Util
{
    using System;
    using EthSharp.Util;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RlpTest
    {
        [TestMethod]
        public void EncodeSingleByteAsOneByte()
        {
            var result = Rlp.EncodeByte(0x01);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(0x01, result[0]);
        }
    }
}
