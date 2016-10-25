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
    public async Task<ActionResult> GetPayments()
    {
      using (var db = new comessa5Entities())
      {
        #region Get Payments
        DateTime paymentsOlderThan = DateTime.Now;
        paymentsOlderThan -= TimeSpan.FromHours(paymentsOlderThan.Hour);

        //int id = (int)Session["UserID"];
        List<PaymentViewModel> payments = await db.cpayment.Include("cuser")
          .Where(payment => payment.date > paymentsOlderThan)
          .Select(paymentInfo => new PaymentViewModel
          {
            ID = paymentInfo.id,
            Value = paymentInfo.amount,
            Comment = paymentInfo.comment,
            SenderName = paymentInfo.cuser.name,
            RecipientName = paymentInfo.recipientId.ToString(),
            Type = (PaymentType)paymentInfo.type
          }
          ).ToListAsync();

        return PartialView("PaymentsView", payments);
        #endregion
      }
    }
  }
}