using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;
using System.Threading.Tasks;
using Comessa6.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Comessa6.Controllers
{
  public class PaymentsController : Controller
  {
    // GET: Orders
    [HttpGet]
    public async Task<ActionResult> GetPayments(int userID)
    {
      using (var db = new comessa5Entities())
      {
        #region Get Payments
        DateTime paymentsOlderThan = DateTime.Now;
        paymentsOlderThan -= TimeSpan.FromHours(paymentsOlderThan.Hour);

        //int id = (int)Session["UserID"];
        List<PaymentViewModel> payments = await db.vpayment
          .Where(payment => userID == -1 ?  (payment.date > paymentsOlderThan) : (payment.recipientId == userID || payment.senderId == userID))
          .Select(paymentInfo => new PaymentViewModel
          {
            ID = paymentInfo.id,
            Value = paymentInfo.amount,
            Comment = paymentInfo.comment,
            SenderID = paymentInfo.senderId,
            RecipientID = paymentInfo.recipientId,
            SenderName = paymentInfo.senderName,
            RecipientName = paymentInfo.recipientName,
            Type = (PaymentType)paymentInfo.type,
            Date = paymentInfo.date
          }
          ).ToListAsync();

        return PartialView("PaymentsView", payments);
        #endregion
      }
    }
  }
}