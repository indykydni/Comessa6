using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Comessa6
{
    public static class Utils
    {
        /// <summary>
        /// Returns the pwd in plaintext
        /// </summary>
        /// <param name="input">MD5 hashed password</param>
        /// <returns>password</returns>
        public static string CalculateMD5Hash(this string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("X2"));

                return sb.ToString();
            }
        }

        /// <summary>
        /// Razor has problems with defining when it's in debug mode
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static bool IsDebug(this HtmlHelper htmlHelper)
        {
#if DEBUG
            return true;
#else
      return false;
#endif
        }
    }

    /// <summary>
    /// As already defined in the existing DB
    /// </summary>
    public enum OrderStatus
    {
        Ordered = 0,
        InProgress = 1,
        Done = 2,
        Payment = 99
    }
}