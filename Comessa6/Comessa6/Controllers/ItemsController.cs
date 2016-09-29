using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Comessa6.Models;
using Comessa6.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Comessa6.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet]
    public async Task<ActionResult> GetItems(int providerID)
    {
      using (var db = new comessa5Entities())
      {
        //List<ItemViewModel> items = new List<ItemViewModel>();
        List<ItemViewModel> items = await (from citem item 
                                   in db.citem
                                   where item.providerId == providerID
                                   select new ItemViewModel
                                   {
                                     ID = item.id,
                                     Name = item.name,
                                     Price = item.price,
                                     Priority = item.priority
                                   }).ToListAsync();
        return PartialView("ItemsView", items.OrderBy(item => item.Priority));
      }
    }
  }
}