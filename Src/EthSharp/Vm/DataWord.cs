namespace EthSharp.Vm
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

    public class DataWord
    {
        private byte[] data;

        public DataWord(int num)
        {
            this.data = new byte[32];
            int value = num;

            for (int k = 31; k >= 28; k--)
            {
                this.data[k] = (byte)(value & 0x00ff);
                value >>= 8;
            }

            if (num < 0)
                for (int k = 28; k-- > 0; )
                    this.data[k] = (byte)0xff;
        }

        public DataWord(byte[] bytes)
        {
            this.data = new byte[32];

            Array.Copy(bytes, 0, this.data, 32 - bytes.Length, bytes.Length);

            if ((bytes[0] & 0x80) != 0)
                for (int k = 0; k < 32 - bytes.Length; k++)
                    this.data[k] = 0xff;
        }

        public DataWord(BigInteger value)
            : this(value.ToByteArray().Reverse().ToArray())
        {
        }

        public byte[] Data { get { return this.data; } }

        public BigInteger Value { get { return new BigInteger(this.data.Reverse().ToArray()); } }

        public DataWord Negate()
        {
            return new DataWord(BigInteger.Negate(this.Value));
        }

        public DataWord Add(DataWord dw)
        {
            return new DataWord(BigInteger.Add(this.Value, dw.Value));
        }

        public DataWord Subtract(DataWord dw)
        {
            return new DataWord(BigInteger.Subtract(this.Value, dw.Value));
        }

        public DataWord Multiply(DataWord dw)
        {
            return new DataWord(BigInteger.Multiply(this.Value, dw.Value));
        }

        public DataWord Divide(DataWord dw)
        {
            return new DataWord(BigInteger.Divide(this.Value, dw.Value));
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is DataWord))
                return false;

            return this.Value.Equals(((DataWord)obj).Value);
        }
    }
}
