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
    private Dictionary<Type, Func<RequestContext, IController>> controllers = new Dictionary<Type, Func<RequestContext, IController>>();

    public ComessaControllerFactory(comessa5Entities repository)
    {
      controllers[typeof(AuthenticationController)] = controller => new AuthenticationController(repository);
      controllers[typeof(HomeController)] = controller => new HomeController(repository);
      controllers[typeof(ItemsController)] = controller => new ItemsController(repository);
      controllers[typeof(OrdersController)] = controller => new OrdersController(repository);
      controllers[typeof(PaymentsController)] = controller => new PaymentsController(repository);
    }

    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
      if (!controllers.ContainsKey(controllerType))
        return base.GetControllerInstance(requestContext, controllerType);
      return controllers[controllerType](requestContext);
    }
  }
}
