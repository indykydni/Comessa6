using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Comessa6.Controllers;
using System.Web.Mvc;

namespace Comessa6.Tests.Controllers
{
  [TestFixture]
  public class OrdersController_CreateOrder
  {
    [Test]
    public void OrdersController_CreateOrder_ReturnsCorrectView()
    {
      var controller = new OrdersController();
      var result = controller.CreateOrder(2) as PartialViewResult;
      Assert.IsNotNull(result);
      Assert.AreEqual(result.ViewName, "CreateOrderView");
    }
  }
}
