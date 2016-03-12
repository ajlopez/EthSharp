namespace EthSharp.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Hex
    {
        // http://stackoverflow.com/questions/311165/how-do-you-convert-byte-array-to-hexadecimal-string-and-vice-versa

        public static string ToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            hex.Append("0x");
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
