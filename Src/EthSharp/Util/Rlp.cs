namespace EthSharp.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Rlp
    {
        private static readonly int OffsetShortItem = 0x80;

        public static byte[] EncodeByte(byte singleByte) 
        {
            if ((singleByte & 0xff) == 0)
                return new byte[] { (byte)OffsetShortItem };

            if ((singleByte & 0xff) <= 0x7f)
                return new byte[] { singleByte };

            return new byte[] { (byte)(OffsetShortItem + 1), singleByte };
        }

        public static byte[] EncodeBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return new byte[] { (byte)OffsetShortItem };

            if (bytes.Length == 1 && bytes[0] >= 0x80)
                return new byte[] { (byte)(OffsetShortItem + 1), bytes[0] };

            return bytes;
        }
    }
}
