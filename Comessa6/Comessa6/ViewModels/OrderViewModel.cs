using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comessa6.Models;

namespace Comessa6.ViewModels
{
    public class OrderViewModel
    {
        //public OrderViewModel(corder order)
        //{
        //  this.order = order;
        //  this.ItemName = order.itemName
        //}

        public int ID { get; set; }
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public string ProviderName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public OrderStatus Status { get; set; }
        public bool ForCurrentUserOnly { get; set; }
        public DateTime Date { get; set; }
    }
}