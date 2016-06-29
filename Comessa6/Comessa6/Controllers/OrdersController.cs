using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;
using System.Threading.Tasks;

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
        public async Task<ActionResult> SaveOrder(int itemID, int quantity, string comments)
        {
            //if (string.IsNullOrEmpty(xxx))
            //    RedirectToAction("Index", "Home");

            return Json(true);
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            // Delete the item in the database
            return Json(true); // or if there is an error, return Json(null); to indicate failure
        }
    }
}