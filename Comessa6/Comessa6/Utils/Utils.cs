using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

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
  }
}