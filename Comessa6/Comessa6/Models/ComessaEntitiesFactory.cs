using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class ComessaEntitiesFactory : IComessaEntitiesFactory
  {
    //Comessa5Context context;
    //public ComessaEntitiesFactory()
    //{
    //  context = new Comessa5Context();
    //}
    public virtual Comessa5Context GetContext() => new Comessa5Context();

    //public void Dispose()
    //{
    //  this.context.Dispose();
    //}
  }
}