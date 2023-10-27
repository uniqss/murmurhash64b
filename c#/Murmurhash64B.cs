using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace utility
{
    public class MurmurHash64B
    {
        public static ulong MakeHashValue(byte[] key, uint seed = 0xee6b27eb)
        {
            uint len = (uint)key.Length;
            const uint m = 0x5bd1e995;
            const int r = 24;
 
            uint h1 = seed ^ len;
            uint h2 = 0;
            int pos = 0;
 
            while (len >= 8)
            {
                uint k1 = System.BitConverter.ToUInt32(key, pos);
                pos += 4;
                k1 *= m; k1 ^= k1 >> r; k1 *= m;
                h1 *= m; h1 ^= k1;
                len -= 4;
 
                uint k2 = System.BitConverter.ToUInt32(key, pos);
                pos += 4;
                k2 *= m; k2 ^= k2 >> r; k2 *= m;
                h2 *= m; h2 ^= k2;
                len -= 4;
            }
 
            if (len >= 4)
            {
                uint k1 = System.BitConverter.ToUInt32(key, pos);
                pos += 4;
                k1 *= m; k1 ^= k1 >> r; k1 *= m;
                h1 *= m; h1 ^= k1;
                len -= 4;
            }
 
            if (len == 3)
            {
                h2 ^= (uint)key[pos + 2] << 16;
                h2 ^= (uint)key[pos + 1] << 8;
                h2 ^= (uint)key[pos + 0];
                h2 *= m;
            }
            else if (len == 2)
            {
                h2 ^= (uint)key[pos + 1] << 8;
                h2 ^= (uint)key[pos + 0];
                h2 *= m;
            }
            else if (len == 1)
            {
                h2 ^= (uint)key[pos + 0];
                h2 *= m;
            }
 
            h1 ^= h2 >> 18; h1 *= m;
            h2 ^= h1 >> 22; h2 *= m;
            h1 ^= h2 >> 17; h1 *= m;
            h2 ^= h1 >> 19; h2 *= m;
 
            ulong h = h1;
 
            h = (h << 32) | h2;
 
            return h;
        }
 
        public static ulong StringToHashValue(string source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(long v1, int v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[v1bytes.Length + v2bytes.Length];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, v1bytes.Length);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, v1bytes.Length, v2bytes.Length);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(long v1, uint v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[v1bytes.Length + v2bytes.Length];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, v1bytes.Length);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, v1bytes.Length, v2bytes.Length);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(ulong v1, int v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[v1bytes.Length + v2bytes.Length];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, v1bytes.Length);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, v1bytes.Length, v2bytes.Length);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(ulong v1, uint v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[v1bytes.Length + v2bytes.Length];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, v1bytes.Length);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, v1bytes.Length, v2bytes.Length);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(long v1, long v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[v1bytes.Length + v2bytes.Length];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, v1bytes.Length);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, v1bytes.Length, v2bytes.Length);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(long v1, ulong v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[12];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, 8);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, 8, 4);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(ulong v1, long v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[v1bytes.Length + v2bytes.Length];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, v1bytes.Length);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, v1bytes.Length, v2bytes.Length);
            return MakeHashValue(bytes);
        }
        public static ulong HashII(ulong v1, ulong v2)
        {
            byte[] v1bytes = System.BitConverter.GetBytes(v1);
            byte[] v2bytes = System.BitConverter.GetBytes(v2);
            byte[] bytes = new byte[12];
            System.Buffer.BlockCopy(v1bytes, 0, bytes, 0, 8);
            System.Buffer.BlockCopy(v2bytes, 0, bytes, 8, 4);
            return MakeHashValue(bytes);
        }
    }
}

