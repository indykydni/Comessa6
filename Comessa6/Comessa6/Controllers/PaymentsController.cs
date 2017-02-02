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
    private comessa5Entities repository;

    public PaymentsController(comessa5Entities repository)
    {
      this.repository = repository;
    }
    // GET: Orders
    [HttpGet]
    public async Task<ActionResult> GetPayments(int userID)
    {
      #region Get Payments
      DateTime paymentsOlderThan = DateTime.Now;
      paymentsOlderThan -= TimeSpan.FromHours(paymentsOlderThan.Hour);
      List<PaymentViewModel> payments = await (from payment in repository.vpayment
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