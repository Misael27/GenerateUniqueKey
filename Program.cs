using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        internal static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        static void Main(string[] args)
        {
            Console.WriteLine("Unique Key: "+ GetUniqueKey(32));
            var val = Console.ReadLine();
        }

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;
                result.Append(chars[idx]);
            }
            return result.ToString();
        }
    }
}
