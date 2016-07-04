using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;
using System.Threading.Tasks;
using Comessa6.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Comessa6.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            using (var db = new comessa5Entities())
            {
                #region Get orders
                //int id = (int)Session["UserID"];
                List<OrderViewModel> orders = await db.corder.Include("citem").Include("citem.cprovider").Include("cuser")
                  .Where(order => order.date > DateTime.Today)
                  .OrderByDescending(order => order.date)
                  .Select(orderInfo => new OrderViewModel
                  {
                      ID = orderInfo.id,
                      ItemName = orderInfo.citem.name,
                      Price = orderInfo.price,
                      Comment = orderInfo.comment,
                      ProviderName = orderInfo.citem.cprovider.name,
                      Status = (OrderStatus)orderInfo.status,
                      UserName = orderInfo.cuser.name
                  }
                  ).ToListAsync();
                
                return PartialView("OrdersView", orders);
                #endregion
            }
        }
        [HttpGet]
        public ActionResult CreateOrder(int itemID)
        {
          return PartialView("CreateOrderView", new OrderViewModel { ItemID = itemID, Quantity = 1 });
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder(int itemID, int quantity, string comments)
        {
            using (var db = new comessa5Entities())
            {
                //ToDo: check if it's possible to do that using 1 operation instead of 2 using EF
                //...or parse the whole citem as argument here
                citem item = db.citem.Where(citem => citem.id == itemID).FirstOrDefault();
                db.corder.Add(new corder
                {
                    itemId = itemID,
                    quantity = quantity,
                    comment = comments,
                    userId = (int)Session["UserID"],
                    itemName = item.name,
                    price = item.price,
                    date = DateTime.Now,
                    status = (int)OrderStatus.Ordered,
                    sellerId = -1//??? as in the desktop app
                });
                await db.SaveChangesAsync();
            }
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