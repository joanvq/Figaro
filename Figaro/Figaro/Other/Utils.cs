using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XLabs.Cryptography;

namespace Figaro.Other
{
    public sealed class Utils
    {
        public  bool IsValidEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public string HashPass(string originalpassword)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = new UTF8Encoding().GetBytes(originalpassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            string added = "ew#%¬plfñ@@|ºdaç";
            Byte[] additionalBytes = new UTF8Encoding().GetBytes(added);

            int length = 0;
            if (encodedBytes.Length < additionalBytes.Length)
            {
                length = encodedBytes.Length;
            }
            else
            {
                length = additionalBytes.Length;
            }
            for (int i = 0; i < length; i++)
            {
                encodedBytes[i] = (byte)(encodedBytes[i] ^ additionalBytes[i]);
            }
            string hex = BitConverter.ToString(encodedBytes).Replace("-", "");
            
            return hex;
        }
    }
}
