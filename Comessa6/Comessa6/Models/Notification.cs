using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class Notification
  {
    private int id;
    private int userId;
    private User user;
    private DateTime date;
    private string text;

    public int Id
    {
      get { return this.id; }
      set { this.id = value; }
    }

    public int UserId
    {
      get { return this.userId; }
      set { this.userId = value; }
    }

    public User User
    {
      get { return this.user; }
      set { this.user = value; }
    }

    public DateTime Date
    {
      get { return this.date; }
      set { this.date = value; }
    }

    public string Text
    {
      get { return this.text; }
      set { this.text = value; }
    }

    public Notification()
    {
    }

    public Notification(int id, int userId, DateTime datetime, string message)
    {
      this.id = id;
      this.userId = userId;
      this.date = datetime;
      this.text = message;
    }
  }
}