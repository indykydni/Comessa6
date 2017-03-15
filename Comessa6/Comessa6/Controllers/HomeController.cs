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
    private IComessaEntitiesFactory factory;

    public HomeController(IComessaEntitiesFactory factory)
    {
      this.factory = factory;
    }

    [Authorize]
    public ActionResult Index()
    {
      if (Session["UserID"] == null)
      {
        //System.Web.Security.FormsAuthentication.GetAuthCookie()
        return RedirectToAction("Login", "Authentication");
      }
      IndexViewModel indexVM = new IndexViewModel();
      #region Get Providers
      indexVM.Providers = new ProvidersViewModel();
      using (Comessa5Context repository = factory.GetContext())
      {
        var itemsInfo = repository.cprovider.OrderBy(provider => provider.priority);
        foreach (var providerInfo in itemsInfo)
        {
          ProviderViewModel providerVM = new ProviderViewModel { ID = providerInfo.id, Name = providerInfo.name, IsVisible = providerInfo.isVisible, TodaysDinner = (DateTime.Today.Year.Equals(providerInfo.dinnerLastModified.Year) && (DateTime.Today.DayOfYear.Equals(providerInfo.dinnerLastModified.DayOfYear))) ? providerInfo.dinnerText : null };
          indexVM.Providers.Providers.Add(providerVM);
        }
      }
        #endregion
      
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