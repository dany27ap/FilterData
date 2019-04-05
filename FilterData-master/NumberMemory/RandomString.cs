using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace NumberMemory {
    class RandomString {
        public static string getUnuiqueString(int size) {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider()) {
                crypto.GetBytes(data);
            }
            StringBuilder sb = new StringBuilder(size);
            foreach(byte b in data) {
                sb.Append(chars[b % (chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
