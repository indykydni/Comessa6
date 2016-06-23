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
        [HttpGet]
        public ActionResult CreateOrder(int itemID)
        {
          return PartialView("CreateOrderView", new OrderViewModel { ItemID = itemID, Quantity = 1 });
        }

        [HttpPost]
        public ActionResult SaveOrder(OrderViewModel orderVM)
        {

            return new EmptyResult();
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            // Delete the item in the database
            return Json(true); // or if there is an error, return Json(null); to indicate failure
        }
    }
}