using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Common.Extensions
{
    public class CommonMethods
    {
        /// <summary>
        /// Create unique alphanumeric string of given length, taken from http://stackoverflow.com/a/1344255
        /// </summary>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static string GetUniqueKey(int maxSize = 8)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        /// <summary>
        /// Create unique alphanumeric string of given length, taken from http://stackoverflow.com/a/1344255
        /// </summary>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static string GetRandomNumbers(int maxSize = 8)
        {
            char[] chars = new char[62];
            chars =
            "1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static long CombineNumbers(params long?[] s)
        {
            if (s == null) return 0;
            if (!s.Any()) return 0;
            var result = "";
            foreach (var item in s)
            {
                result += item;
            }

            long g = 0;
            long.TryParse(result, out g);
            return g;
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}
