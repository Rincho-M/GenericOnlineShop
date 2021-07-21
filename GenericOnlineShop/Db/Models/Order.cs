using System;
using System.Collections.Generic;

#nullable disable

namespace GenericOnlineShop.Db.Models
{
    public partial class Order
    {
        public Order()
        {
            ProductInOrders = new HashSet<ProductInOrder>();
        }

        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint StatusId { get; set; }
        public DateTime Date { get; set; }

        public virtual OrderStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
