namespace EthSharp.Tests.Util
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EthSharp.Util;

    [TestClass]
    public class HexTests
    {
        [TestMethod]
        public void ByteArrayToString()
        {
            Assert.AreEqual("0x010203", Hex.ToString(new byte[] { 0x01, 0x02, 0x03 }));
        }
    }
}
