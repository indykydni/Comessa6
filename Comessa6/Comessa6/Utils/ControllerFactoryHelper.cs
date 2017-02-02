using Comessa6.Controllers;
using Comessa6.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comessa6
{
  public class ControllerFactoryHelper
  {
    public static IControllerFactory GetControllerFactory()
    {
      string repositoryTypeName = ConfigurationManager.AppSettings["repository"];
      var repositoryType = Type.GetType(repositoryTypeName);
      var repository = Activator.CreateInstance(repositoryType);
      IControllerFactory factory = new ComessaControllerFactory(repository as comessa5Entities);
      return factory;
    }
  }
}