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

    public ActionResult Logout()
    {
      FormsAuthentication.SignOut();
      return RedirectToAction("Login");
    }

    // GET: Authentication
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult DoLogin(UserDetails u)
    {
      if (ModelState.IsValid)
      {
        return RedirectToAction("Index", "Home");
        //EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
        //if (bal.IsValidUser(u))
        //{
        //  FormsAuthentication.SetAuthCookie(u.Name, false);
        //  return RedirectToAction("Index", "Employee");
        //}
        //else
        //{
        //  ModelState.AddModelError("CredentialError", "Invalid Name or Password");
        //  return View("Login");
        //}
      }
      return View("Login");
    }
  }
}