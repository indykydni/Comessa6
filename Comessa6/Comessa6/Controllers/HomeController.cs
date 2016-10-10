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
      using (var db = new comessa5Entities())
      {
        #region Get Providers with Items
        //indexVM.Providers = new ProvidersViewModel();
        //var itemsInfo = db.citem.Include("cprovider").Where(item => item.isVisible).OrderBy(item => item.cprovider.priority).ThenBy(item => item.priority);
        //foreach (var itemInfo in itemsInfo)
        //{
        //  ItemViewModel itemVM = new ItemViewModel { ID = itemInfo.id, Name = itemInfo.name, Price = itemInfo.price };
        //  ProviderViewModel providerVM = indexVM.Providers.Providers.Where(prov => prov.ID.Equals(itemInfo.providerId)).FirstOrDefault();
        //  if (!itemInfo.providerId.HasValue)
        //    continue;
        //  if (providerVM == null)
        //  {
        //    providerVM = new ProviderViewModel { Name = itemInfo.cprovider.name, ID = itemInfo.providerId.Value };
        //    indexVM.Providers.Providers.Add(providerVM);
        //  }

        //  providerVM.Items.Add(itemVM);
        //}
        #endregion
        #region Get Providers
        indexVM.Providers = new ProvidersViewModel();
        var itemsInfo = db.cprovider.OrderBy(provider => provider.priority);
        foreach (var providerInfo in itemsInfo)
        {
          ProviderViewModel providerVM = new ProviderViewModel { ID = providerInfo.id, Name = providerInfo.name, IsVisible = providerInfo.isVisible, TodaysDinner = (DateTime.Today.Year.Equals(providerInfo.dinnerLastModified.Year) && (DateTime.Today.DayOfYear.Equals(providerInfo.dinnerLastModified.DayOfYear))) ? providerInfo.dinnerText : null };
          indexVM.Providers.Providers.Add(providerVM);
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