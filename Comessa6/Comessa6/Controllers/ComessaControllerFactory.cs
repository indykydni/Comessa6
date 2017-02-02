using Comessa6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Comessa6.Controllers
{
  public class ComessaControllerFactory : DefaultControllerFactory
  {
    private Dictionary<string, Func<RequestContext, IController>> controllers = new Dictionary<string, Func<RequestContext, IController>>();

    public ComessaControllerFactory(comessa5Entities repository)
    {
      controllers["Authentication"] = controller => new AuthenticationController(repository);
      controllers["Home"] = controller => new HomeController(repository);
      controllers["Items"] = controller => new ItemsController(repository);
      controllers["Orders"] = controller => new OrdersController(repository);
      controllers["Payments"] = controller => new PaymentsController(repository);
    }

    public override IController CreateController(RequestContext requestContext, string controllerName)
    {
      if (!controllers.ContainsKey(controllerName))
        return base.CreateController(requestContext, controllerName);
      return controllers[controllerName](requestContext);
    }
  }
}
