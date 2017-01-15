using Comessa6.Tests.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comessa6.TestsDebug
{
  class Program
  {
    static void Main(string[] args)
    {
      var test = new OrdersController_CreateOrder();
      test.ReturnsCorrectView();
    }
  }
}
