namespace EthSharp.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Rlp
    {
        public static byte[] EncodeByte(byte singleByte) 
        {
            return new byte[] { singleByte };
        }
    }
}
