using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;

namespace Comessa6.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult CreateOrder(int itemID)
        {
          return PartialView("CreateOrderView", new OrderViewModel { ItemID = itemID, Quantity = 1 });
        }
    }
}