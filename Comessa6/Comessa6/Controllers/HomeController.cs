using Comessa6.Models;
using Comessa6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comessa6.Controllers
{
  public class HomeController : Controller
  {
    [Authorize]
    public ActionResult Index()
    {
      if (Session["UserID"] == null)
      {
        //System.Web.Security.FormsAuthentication.GetAuthCookie()
        return RedirectToAction("Login", "Authentication");
      }
      IndexViewModel indexVM = new IndexViewModel();
      indexVM.RecentOrders = new OrdersViewModel();
      using (var db = new comessa5Entities())
      {
        #region Get orders
        int id = (int)Session["UserID"];
        var ordersInfo = db.corder.Include("citem").Include("citem.cprovider")
          .Where(order => order.userId == id).OrderByDescending(order => order.date).Take(10);

        foreach (var orderInfo in ordersInfo)
        {
          indexVM.RecentOrders.Orders.Add(new OrderViewModel
          {
            ID = orderInfo.id,
            ItemName = orderInfo.citem.name,
            Price = orderInfo.price,
            Comment = orderInfo.comment,
            ProviderName = orderInfo.citem.cprovider.name,
            Status = (OrderStatus)orderInfo.status
          });
        }
        #endregion
        #region Get Items
        indexVM.Providers = new Dictionary<string, List<ItemViewModel>>();
        var itemsInfo = db.citem.Include("cprovider").Where(item => item.isVisible).OrderBy(item => item.cprovider.priority).ThenBy(item => item.priority);
        foreach (var itemInfo in itemsInfo)
        {
          ItemViewModel itemVM = new ItemViewModel { ID = itemInfo.id, Name = itemInfo.name, Price = itemInfo.price };
          if (indexVM.Providers.ContainsKey(itemInfo.cprovider.name))
            indexVM.Providers[itemInfo.cprovider.name].Add(itemVM);
          else
            indexVM.Providers.Add(itemInfo.cprovider.name, new List<ItemViewModel> { itemVM});
        }
        #endregion
      }
      return View(indexVM);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}