namespace EthSharp.Tests.Core
{
    using System;
    using EthSharp.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBlockWithNumber()
        {
            var block = new Block(1);

            Assert.AreEqual(1, block.Number);
        }
    }
}
