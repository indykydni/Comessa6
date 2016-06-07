using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comessa6.ViewModels;

namespace WebApplication1.Filters
{
  public class HeaderFooterFilter : ActionFilterAttribute
  {
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
      ViewResult v = filterContext.Result as ViewResult;
      if (v != null) // v will null when v is not ViewResult
      {
        BaseViewModel bvm = v.Model as BaseViewModel;
        if (bvm != null)//It’s a view where Header and footer is not required
        {
          bvm.UserName = HttpContext.Current.User.Identity.Name;
          bvm.FooterData = new FooterViewModel();
          bvm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
          bvm.FooterData.Year = DateTime.Now.Year.ToString();
        }
      }
    }
  }
}