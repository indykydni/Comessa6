using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Comessa6.Models;

namespace Comessa6.Controllers
{
  [AllowAnonymous]
  public class AuthenticationController : Controller
  {
    private IComessaEntitiesFactory factory;

    public AuthenticationController(IComessaEntitiesFactory factory)
    {
      this.factory = factory;
    }

    public ActionResult Logout()
    {
      FormsAuthentication.SignOut();
      Session["UserName"] = null;
      return RedirectToAction("Login");
    }

    // GET: Authentication
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult DoLogin(UserViewModel u)
    {
      if (ModelState.IsValid)
      {
        using (Comessa5Context repository = factory.GetContext())
        {
          cuser dbUser = repository.cuser.Where(user => string.Equals(user.login, u.Name)).FirstOrDefault();
          if (dbUser == null || !string.Equals(u.Password.CalculateMD5Hash(), dbUser.password, StringComparison.InvariantCultureIgnoreCase))
          {
            ModelState.AddModelError("CredentialError", "Invalid Name or Password");
            return View("Login");
          }

          Session["UserName"] = u.Name;
          Session["UserID"] = dbUser.id;
          Session["UserIDForOrders"] = -1;
          Session["IsAdmin"] = dbUser.isServer;
          FormsAuthentication.SetAuthCookie(u.Name, u.RememberMe);
        }
        return RedirectToAction("Index", "Home");
      }
      return View("Login");
    }
  }
}
