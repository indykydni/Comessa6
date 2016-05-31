using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class Provider
  {
    private int id;
    private string name;
    private string address;
    private string www;
    private string phone;
    private bool isDinner;
    private string dinnerText;
    private DateTime dinnerLastModified;
    private int priority;

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string Address
    {
      get { return address; }
      set { address = value; }
    }

    public string WWW
    {
      get { return www; }
      set { www = value; }
    }

    public string Phone
    {
      get { return phone; }
      set { phone = value; }
    }

    public bool IsDinner
    {
      get { return this.isDinner; }
      set { this.isDinner = value; }
    }

    public string DinnerText
    {
      get { return dinnerText; }
      set { dinnerText = value; }
    }

    public DateTime DinnerLastModified
    {
      get { return dinnerLastModified; }
      set { dinnerLastModified = value; }
    }

    public int Priority
    {
      get { return priority; }
      set { priority = value; }
    }

    public Provider()
    {
    }

    public Provider(int id, string name, string address, string www, string phone, bool isDinner, string dinnerText, DateTime dinnerLastModified, int priority)
    {
      this.id = id;
      this.name = name;
      this.address = address;
      this.www = www;
      this.phone = phone;
      this.isDinner = isDinner;
      this.dinnerText = dinnerText;
      this.dinnerLastModified = dinnerLastModified;
      this.priority = priority;
    }
  }
}