using System;
using System.Collections.Generic;
using System.Globalization;
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
    //public decimal GetUserBalance(User user)
    //{
    //    if (user == null)
    //        return 0;

    //    decimal balance = 0;

    //    // get negative balance
    //    object result = this.ExecuteScalar("SELECT SUM(o.`amount` * ip.`price`) FROM `Order` o LEFT JOIN `ItemPrice` ip ON o.`itemPriceId` = ip.`id` WHERE o.`userId` = ? AND o.`status` = 2", user.Id);
    //    if (result is DBNull == false && result != null)
    //        balance -= Convert.ToDecimal(result);

    //    // get positive balance
    //    result = this.ExecuteScalar("SELECT SUM(o.`amount` * ip.`price`) FROM `Order` o LEFT JOIN `ItemPrice` ip ON o.`itemPriceId` = ip.`id` WHERE o.`sellerId` = ? AND o.`status` = 2", user.Id);
    //    if (result is DBNull == false && result != null)
    //        balance += Convert.ToDecimal(result);

    //    // get negative balance 
    //    result = this.ExecuteScalar("SELECT SUM(t.`amount`) FROM `Transfer` t WHERE (t.`senderId` = ? AND t.`type` = 0) OR (t.`recipientId` = ? AND t.`type` = 1)", user.Id, user.Id);
    //    if (result is DBNull == false && result != null)
    //        balance -= Convert.ToDecimal(result);

    //    // get positive balance
    //    result = this.ExecuteScalar("SELECT SUM(t.`amount`) FROM `Transfer` t WHERE (t.`recipientId` = ? AND t.`type` = 0) OR (t.`senderId` = ? AND t.`type` = 1)", user.Id, user.Id);
    //    if (result is DBNull == false && result != null)
    //        balance += Convert.ToDecimal(result);

    //    return balance;
    //}

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

    public enum PaymentType
    {
        Transfer = 0,
        Payment = 1
  }
  public class DecimalModelBinder : IModelBinder
  {
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

      ModelState modelState = new ModelState { Value = valueResult };

      object actualValue = null;

      if (valueResult.AttemptedValue != string.Empty)
      {
        try
        {
          actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
        }
        catch (FormatException e)
        {
          modelState.Errors.Add(e);
        }
      }

      bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

      return actualValue;
    }
  }
}