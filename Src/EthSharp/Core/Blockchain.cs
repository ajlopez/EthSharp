namespace EthSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Blockchain
    {
        private Block block;

        public Blockchain(Block block)
        {
            this.block = block;
        }

        public long BestBlockNumber { get { return this.block.Number; } }
    }
}
