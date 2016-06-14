using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comessa6.Models;

namespace Comessa6.ViewModels
{
  public class ProviderViewModel
  {
    //public OrderViewModel(corder order)
    //{
    //  this.order = order;
    //  this.ItemName = order.itemName
    //}

    public int ID { get; set; }
    public string ItemName { get; set; }
    public string ProviderName { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public string UserName { get; set; }
    public string Comment { get; set; }
    public int Priority { get; set; }
    public OrderStatus Status { get; set; }

    public override bool Equals(object obj)
    {
      ProviderViewModel other = obj as ProviderViewModel;
      if (other == null) return false;
      return this.ID == other.ID;
    }

    public override int GetHashCode()
    {
      return this.ID ^ this.Priority;
    }
  }
}