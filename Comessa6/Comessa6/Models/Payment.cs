using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class Payment
  {
    public enum PaymentType
    {
      Transfer = 0,
      Payment = 1,
    }

    private int id;
    private string comment;
    private PaymentType type;
    private int senderId;
    private int recipientId;
    private double amount;
    private DateTime date;

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public string Comment
    {
      get { return comment; }
      set { comment = value; }
    }

    public PaymentType Type
    {
      get { return type; }
      set { type = value; }
    }

    public int SenderId
    {
      get { return senderId; }
      set { senderId = value; }
    }

    public int RecipientId
    {
      get { return recipientId; }
      set { recipientId = value; }
    }

    public double Amount
    {
      get { return amount; }
      set { amount = value; }
    }

    public DateTime Date
    {
      get { return date; }
      set { date = value; }
    }

    public Payment()
    {
    }
  }
}