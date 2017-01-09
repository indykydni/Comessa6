using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;
using System.Threading.Tasks;
using Comessa6.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Comessa6.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        [HttpGet]
        public async Task<ActionResult> GetOrders(int userID)
        {
            using (var db = new comessa5Entities())
            {
                List<OrderViewModel> orders = null;
                #region Get todays orders
                if (userID == -1)
                {
                    DateTime ordersOlderThan = DateTime.Now;
                    ordersOlderThan -= TimeSpan.FromHours(ordersOlderThan.Hour);

                    //int id = (int)Session["UserID"];
                    orders = await db.corder.Include("citem").Include("citem.cprovider").Include("cuser")
                      .Where(order => order.date > ordersOlderThan)
                      .OrderByDescending(order => order.citem.cprovider.id)
                      .Select(orderInfo => new OrderViewModel
                      {
                          ID = orderInfo.id,
                          ItemName = orderInfo.citem.name,
                          ItemID = (int)orderInfo.itemId,
                          Price = orderInfo.price,
                          Quantity = orderInfo.quantity,
                          Comment = orderInfo.comment,
                          ProviderName = orderInfo.citem.cprovider.name,
                          Status = (OrderStatus)orderInfo.status,
                          UserName = orderInfo.cuser.name,
                          UserID = orderInfo.userId ?? -1,
                          ForCurrentUserOnly = false
                      }
                      ).ToListAsync();
                }
                #endregion
                #region get orders for current user
                else
                {
                    orders = await db.corder.Include("citem").Include("citem.cprovider").Include("cuser")
                     .Where(order => order.userId == userID)
                     .OrderByDescending(order => order.id)
                     .Select(orderInfo => new OrderViewModel
                     {
                         ID = orderInfo.id,
                         ItemName = orderInfo.citem.name,
                         ItemID = (int)orderInfo.itemId,
                         Price = orderInfo.price,
                         Quantity = orderInfo.quantity,
                         Comment = orderInfo.comment,
                         ProviderName = orderInfo.citem.cprovider.name,
                         Status = (OrderStatus)orderInfo.status,
                         UserName = orderInfo.cuser.name,
                         UserID = orderInfo.userId ?? -1,
                         ForCurrentUserOnly = true,
                         Date = orderInfo.date
            }
                     ).ToListAsync();
                }
                #endregion
                return PartialView("OrdersView", orders);
            }
        }
        [HttpGet]
        public ActionResult CreateOrder(int itemID)
        {
            return PartialView("CreateOrderView", new OrderViewModel { ItemID = itemID, Quantity = 1 });
        }

        [HttpGet]
        public ActionResult CreateOrderFromOrder(int itemID, string comment)
        {
            return PartialView("CreateOrderView", new OrderViewModel { ItemID = itemID, Quantity = 1, Comment = comment });
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder(int itemID, decimal quantity, string comments)
        {
            using (var db = new comessa5Entities())
            {
                //ToDo: check if it's possible to do that using 1 operation instead of 2 using EF
                //...or parse the whole citem as argument here
                citem item = db.citem.Where(citem => citem.id == itemID).FirstOrDefault();
                cuser server = db.cuser.Where(cuser => cuser.isServer && !cuser.isMasterServer).FirstOrDefault();
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
                    sellerId = server == null ? -1 : server.id
                });
                await db.SaveChangesAsync();
            }
            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteOrder(int ID)
        {
            using (var db = new comessa5Entities())
            {
                var toRemove = db.corder.Where(order => order.id == ID).SingleOrDefault();
                if (toRemove == null) return Json(false);
                db.corder.Remove(toRemove);
                await db.SaveChangesAsync();
            }
            // Delete the item in the database
            return Json(true); // or if there is an error, return Json(null); to indicate failure
        }
    }

}