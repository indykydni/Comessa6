using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;

namespace Comessa6.Controllers
{
  public class ItemsController : Controller
  {
    // GET: Items
    public ActionResult GetItems(int providerID)
    {
      List<ItemViewModel> items = new List<ItemViewModel>();

      return PartialView("ItemsView", items);
    }
  }
}