namespace EthSharp.Tests.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EthSharp.Core;

    [TestClass]
    public class BlockchainTests
    {
        [TestMethod]
        public void CreateBlockchainWithGenesisBlock()
        {
            Block block = new Block(0);
            Blockchain blockchain = new Blockchain(block);

            Assert.AreEqual(0, blockchain.BestBlockNumber);
        }
    }
}
