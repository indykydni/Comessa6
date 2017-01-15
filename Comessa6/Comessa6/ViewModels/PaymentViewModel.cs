using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comessa6.Models;

namespace Comessa6.ViewModels
{
  public class PaymentViewModel
  {
    public int ID { get; set; }
    public decimal Value { get; set; }
    public int? SenderID { get; set; }
    public int? RecipientID { get; set; }
    public string SenderName { get; set; }
    public string RecipientName { get; set; }
    public string Comment { get; set; }
    public PaymentType Type { get; set; }
    public DateTime Date { get; set; }
  }
}