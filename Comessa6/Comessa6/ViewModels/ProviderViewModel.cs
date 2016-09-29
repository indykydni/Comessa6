using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comessa6.Models;

namespace Comessa6.ViewModels
{
  public class ProviderViewModel
  {
    private List<ItemViewModel> items = null;
    public ProviderViewModel()
    {
      this.Items = new List<ItemViewModel>();
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public bool IsVisible { get; set; }

    public List<ItemViewModel> Items
    {
      get
      {
        if (this.items == null)
          this.items = new List<ItemViewModel>();
        return this.items;
      }
      set { this.items = value; }
    }
  }
}