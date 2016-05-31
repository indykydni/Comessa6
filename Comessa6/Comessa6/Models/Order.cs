using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class Order
  {
    public enum COrderStatus
    {
      Ordered = 0,
      InProgress = 1,
      Done = 2,
      Payment = 99
    }

    private int id;
    private int itemId;
    private Item item;
    private string itemName;
    private string comment;
    private double quantity;
    private double price;
    private int userId;
    private User user;
    private int sellerId;
    private COrderStatus status;
    private DateTime date;
    private DateTime lastModified;

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public int ItemId
    {
      get { return itemId; }
      set { itemId = value; }
    }

    public Item Item
    {
      get { return item; }
      set { item = value; }
    }

    public string ItemName
    {
      get { return itemName; }
      set { itemName = value; }
    }

    public string Comment
    {
      get { return comment; }
      set { comment = value; }
    }

    public double Quantity
    {
      get { return quantity; }
      set { quantity = value; }
    }

    public double Price
    {
      get { return price; }
      set { price = value; }
    }

    public int UserId
    {
      get { return userId; }
      set { userId = value; }
    }

    public User User
    {
      get { return user; }
      set { user = value; }
    }

    public int SellerId
    {
      get { return sellerId; }
      set { sellerId = value; }
    }

    public COrderStatus Status
    {
      get { return status; }
      set { status = value; }
    }

    public DateTime Date
    {
      get { return date; }
      set { date = value; }
    }

    public DateTime LastModified
    {
      get { return lastModified; }
      set { lastModified = value; }
    }

    public Order()
    {
    }
  }
}