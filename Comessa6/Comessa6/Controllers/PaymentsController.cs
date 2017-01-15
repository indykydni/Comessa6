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
        List<PaymentViewModel> payments = await (from payment in db.vpayment
          where ((userID == -1 && payment.date > paymentsOlderThan) || payment.recipientId == userID || payment.senderId == userID)
          orderby payment.id descending
          select new PaymentViewModel
          {
              ID = payment.id,
              Value = payment.amount,
              Comment = payment.comment,
              SenderID = payment.senderId,
              RecipientID = payment.recipientId,
              SenderName = payment.senderName,
              RecipientName = payment.recipientName,
              Type = (PaymentType)payment.type,
              Date = payment.date
          }
          ).ToListAsync();
          return PartialView("PaymentsView", payments);
        #endregion
      }
    }
  }
}