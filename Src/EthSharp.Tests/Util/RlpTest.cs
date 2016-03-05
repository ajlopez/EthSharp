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

        [TestMethod]
        public void EncodeSingleBytesAsOneByte()
        {
            for (int k = 0; k < 0x7f; k++)
            {
                var result = Rlp.EncodeByte((byte)k);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Length);
                Assert.AreEqual((byte)k, result[0]);
            }
        }

        [TestMethod]
        public void EncodeNull()
        {
            var result = Rlp.EncodeBytes(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(0x80, result[0]);
        }
    }
}
