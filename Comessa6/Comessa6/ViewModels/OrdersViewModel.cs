using Comessa6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.ViewModels
{
  public class OrdersViewModel
  {
    public OrdersViewModel()
    {
      this.Orders = new List<OrderViewModel>();
    }

    public OrdersViewModel(List<OrderViewModel> orders)
    {
      this.Orders = orders;
    }

    public List<OrderViewModel> Orders { get; set; }
  }
}