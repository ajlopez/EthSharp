namespace EthSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Blockchain
    {
        private IList<Block> blocks = new List<Block>();

        public Blockchain(Block block)
        {
            this.blocks.Add(block);
        }

        public long BestBlockNumber { get { return this.blocks.Last().Number; } }

        public void Add(Block block)
        {
            if (this.BestBlockNumber == block.Number)
                throw new InvalidOperationException("Rejected block");

            this.blocks.Add(block);
        }
    }
}
