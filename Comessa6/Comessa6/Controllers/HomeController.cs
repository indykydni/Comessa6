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
      OrdersViewModel orders = new OrdersViewModel();
      using (var db = new comessa5Entities())
      {
        var s = db.corder.Include("citem");//.Include("cprovider");nestedinclude
    //.Where(corder => corder.userId == (int)Session["UserID"]);
        var ss = (from corder order in db.corder
                  where order.userId.Equals(Session["UserID"])
                  select new OrderViewModel
                  {
                    ItemName = order.itemName,
                    Price = order.price,
                    Comment = order.comment,
                    Quantity = order.quantity,
                    UserName = Session["UserName"].ToString()//,
                                                  //ProviderName = from citem item in db.citem where item.id == order.itemId select item.
                  });
      }
      return View();
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