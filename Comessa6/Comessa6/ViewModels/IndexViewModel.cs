using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.ViewModels
{
  public class IndexViewModel
  {
    public OrdersViewModel RecentOrders { get; set; }
    //key is the providers' name
    public Dictionary<string, List<ItemViewModel>> Providers { get; set; }
  }
}