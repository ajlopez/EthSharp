﻿namespace EthSharp.Vm
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
        }

        public DataWord(byte[] bytes)
        {
            this.data = new byte[32];

            Array.Copy(bytes, 0, this.data, 32 - bytes.Length, bytes.Length);
        }

        public byte[] Data { get { return this.data; } }

        public BigInteger Value { get { return new BigInteger(this.data.Reverse().ToArray()); } }

        public DataWord Add(DataWord dw)
        {
            return new DataWord(BigInteger.Add(this.Value, dw.Value).ToByteArray().Reverse().ToArray());
        }
    }
}
