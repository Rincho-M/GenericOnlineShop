using System;
using System.Collections.Generic;

#nullable disable

namespace GenericOnlineShop.Db.Models
{
    public partial class ProductInOrder
    {
        public uint Id { get; set; }
        public uint ProductId { get; set; }
        public uint OrderId { get; set; }
        public uint Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
