using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class Item
  {
      private int id;
      private string name;
      private string[] keywords;
      private double price;
      private int providerId;
      private Provider provider;
      private bool isVisible;
      private Bitmap image;
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

      public string[] Keywords
      {
        get { return keywords; }
        set { keywords = value; }
      }

      public double Price
      {
        get { return price; }
        set { price = value; }
      }

      public int ProviderId
      {
        get { return providerId; }
        set { providerId = value; }
      }

      public Provider Provider
      {
        get { return provider; }
        set { provider = value; }
      }

      public bool IsVisible
      {
        get { return isVisible; }
        set { isVisible = value; }
      }

      public Bitmap Image
      {
        get { return image; }
        set { image = value; }
      }

      public int Priority
      {
        get { return priority; }
        set { priority = value; }
      }

      public Item()
      {
      }

      public override string ToString()
      {
        return this.Name + " (" + this.Price + " zł)";
      }
    }
  
}