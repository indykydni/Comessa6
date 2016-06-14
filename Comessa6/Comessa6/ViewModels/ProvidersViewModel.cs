using Comessa6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.ViewModels
{
  public class ProvidersViewModel
  {
    public ProvidersViewModel()
    {
      this.Providers = new List<ProviderViewModel>();
    }

    public ProvidersViewModel(List<ProviderViewModel> providers)
    {
      this.Providers = providers;
    }

    public List<ProviderViewModel> Providers { get; set; }
  }
}