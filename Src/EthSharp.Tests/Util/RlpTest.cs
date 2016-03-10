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
        public void EncodeZeroByteAsOneByte()
        {
            var result = Rlp.EncodeByte(0x00);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(0x80, result[0]);
        }

        [TestMethod]
        public void EncodeSingleBytesAsOneByte()
        {
            for (int k = 1; k <= 0x7f; k++)
            {
                var result = Rlp.EncodeByte((byte)k);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Length);
                Assert.AreEqual((byte)k, result[0]);
            }
        }

        [TestMethod]
        public void EncodeBytesAsTwoBytes()
        {
            for (int k = 0x80; k <= 0xff; k++)
            {
                var result = Rlp.EncodeByte((byte)k);

                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Length);
                Assert.AreEqual(0x81, result[0]);
                Assert.AreEqual((byte)k, result[1]);
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

        [TestMethod]
        public void EncodeEmptyArray()
        {
            var result = Rlp.EncodeBytes(new byte[] { });

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(0x80, result[0]);
        }

        [TestMethod]
        public void EncodeArrayWithOneSimpleByte()
        {
            var result = Rlp.EncodeBytes(new byte[] { 0x01 });

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(0x01, result[0]);
        }

        [TestMethod]
        public void EncodeArrayWithSingleByte()
        {
            for (int k = 0; k <= 0x7f; k++)
            {
                var result = Rlp.EncodeBytes(new byte[] { (byte)k });

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Length);
                Assert.AreEqual((byte)k, result[0]);
            }
        }

        [TestMethod]
        public void EncodeArrayWithTwoLowBytes()
        {
            for (int k = 0; k <= 0x7f; k++)
            {
                var result = Rlp.EncodeBytes(new byte[] { (byte)k, (byte)k });

                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Length);
                Assert.AreEqual((byte)k, result[0]);
                Assert.AreEqual((byte)k, result[1]);
            }
        }

        [TestMethod]
        public void EncodeArrayWithHighByte()
        {
            for (int k = 0x80; k <= 0xff; k++)
            {
                var result = Rlp.EncodeBytes(new byte[] { (byte)k });

                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Length);
                Assert.AreEqual(0x81, result[0]);
                Assert.AreEqual((byte)k, result[1]);
            }
        }
    }
}
