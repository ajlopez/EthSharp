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

        public static byte[] EncodeBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return new byte[] { 0x80 };

            return bytes;
        }
    }
}
