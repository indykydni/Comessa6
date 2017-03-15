using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public interface IComessaEntitiesFactory//, IDisposable
  {
    Comessa5Context GetContext();
  }
}