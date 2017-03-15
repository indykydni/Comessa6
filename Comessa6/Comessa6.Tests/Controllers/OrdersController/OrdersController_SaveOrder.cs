using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Comessa6.Controllers;
using System.Web.Mvc;
using Moq;
using Comessa6.Models;
using System.Data.Entity;

namespace Comessa6.Tests.Controllers
{
  [TestFixture]
  public class OrdersController_SaveOrder
  {   
    [Test]
    public void OrdersController_SaveOrder_SavesOrder()
    {
      var users = new List<cuser>
      {
        new cuser{ isServer = true },
        new cuser{ isServer = false }
      }.AsQueryable();
      var items = new List<citem>
      {
        new citem{ id = 1 }
      }.AsQueryable();
      var orders = new List<corder>().AsQueryable();

      var usersMock = new Mock<DbSet<cuser>>();
      usersMock.As<IQueryable<cuser>>().Setup(m => m.Provider).Returns(users.Provider);
      usersMock.As<IQueryable<cuser>>().Setup(m => m.Expression).Returns(users.Expression);
      usersMock.As<IQueryable<cuser>>().Setup(m => m.ElementType).Returns(users.ElementType);
      usersMock.As<IQueryable<cuser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

      var itemsMock = new Mock<DbSet<citem>>();
      itemsMock.As<IQueryable<citem>>().Setup(m => m.Provider).Returns(items.Provider);
      itemsMock.As<IQueryable<citem>>().Setup(m => m.Expression).Returns(items.Expression);
      itemsMock.As<IQueryable<citem>>().Setup(m => m.ElementType).Returns(items.ElementType);
      itemsMock.As<IQueryable<citem>>().Setup(m => m.GetEnumerator()).Returns(items.GetEnumerator());

      var ordersMock = new Mock<DbSet<corder>>();
      ordersMock.As<IQueryable<corder>>().Setup(m => m.Provider).Returns(orders.Provider);
      ordersMock.As<IQueryable<corder>>().Setup(m => m.Expression).Returns(orders.Expression);
      ordersMock.As<IQueryable<corder>>().Setup(m => m.ElementType).Returns(orders.ElementType);
      ordersMock.As<IQueryable<corder>>().Setup(m => m.GetEnumerator()).Returns(orders.GetEnumerator());

      var contextMock = new Mock<Comessa5Context>();
      contextMock.Setup(c => c.cuser).Returns(usersMock.Object);
      contextMock.Setup(c => c.citem).Returns(itemsMock.Object);
      contextMock.Setup(c => c.corder).Returns(ordersMock.Object);

      var factoryMock = new Mock<ComessaEntitiesFactory>();
      factoryMock.Setup(f => f.GetContext()).Returns(contextMock.Object);

      var controller = new OrdersController(factoryMock.Object);
      var result = controller.SaveOrder(1, 2, 3, "fake order");
      //the old way
      //Assert.IsNotNull(result);
      //Assert.AreEqual(result.ViewName, "CreateOrderView");
      Assert.That(result, Is.Not.Null);


      ordersMock.Verify(m => m.Add(It.IsAny<corder>()), Times.Once());
      contextMock.Verify(m => m.SaveChanges(), Times.Once());
    }
  }
}
