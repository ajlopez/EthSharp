﻿namespace EthSharp.Tests.Core
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

        [TestMethod]
        public void AddBlock()
        {
            Block block = new Block(0);
            Block block1 = new Block(1);

            Blockchain blockchain = new Blockchain(block);

            blockchain.Add(block1);

            Assert.AreEqual(1, blockchain.BestBlockNumber);
        }

        [TestMethod]
        public void RejectBlockWithSameNumber()
        {
            Block block = new Block(0);
            Block block1 = new Block(0);

            Blockchain blockchain = new Blockchain(block);

            try
            {
                blockchain.Add(block1);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Rejected block", ex.Message);
            }
        }

        [TestMethod]
        public void RejectBlockWithTooMuchGreaterNumber()
        {
            Block block = new Block(0);
            Block block1 = new Block(2);

            Blockchain blockchain = new Blockchain(block);

            try
            {
                blockchain.Add(block1);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Rejected block", ex.Message);
            }
        }
    }
}
