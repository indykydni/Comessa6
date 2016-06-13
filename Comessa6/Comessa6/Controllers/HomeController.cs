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
        int id = (int)Session["UserID"];
        var ordersInfo = db.corder.Include("citem").Include("citem.cprovider")
          .Where(order => order.userId == id).OrderBy(order => order.date).Take(10);
        //var ss = (from corder order in db.corder
        //          where order.userId.Equals(Session["UserID"])
        //          select new OrderViewModel
        //          {
        //            ItemName = order.itemName,
        //            Price = order.price,
        //            Comment = order.comment,
        //            Quantity = order.quantity,
        //            UserName = Session["UserName"].ToString()//,
        //                                          //ProviderName = from citem item in db.citem where item.id == order.itemId select item.
        //          });
        foreach(var orderInfo in ordersInfo.ToList())
        {
          indexVM.RecentOrders.Orders.Add(new OrderViewModel
          {
            ItemName = orderInfo.citem.name,
            Price = orderInfo.price,
            Comment = orderInfo.comment,
            ProviderName = orderInfo.citem.cprovider.name,
            Status = (OrderStatus)orderInfo.status
          });
        }
        
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