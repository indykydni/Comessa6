﻿using System;
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
        using (var db = new comessa5Entities())
        {
          cuser dbUser = db.cuser.Where(user => string.Equals(user.login, u.Name)).FirstOrDefault();
          if (dbUser == null || !string.Equals(u.Password.CalculateMD5Hash(), dbUser.password, StringComparison.InvariantCultureIgnoreCase))
          {
            ModelState.AddModelError("CredentialError", "Invalid Name or Password");
              return View("Login");
          }
          Session["UserName"] = u.Name;
          Session["UserID"] = dbUser.id;
          Session["IsAdmin"] = dbUser.isServer;
          FormsAuthentication.SetAuthCookie(u.Name, u.RememberMe);
          return RedirectToAction("Index", "Home");
        }
      }
      return View("Login");
    }
  }
}