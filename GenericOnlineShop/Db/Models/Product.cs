using System;
using System.Collections.Generic;

#nullable disable

namespace GenericOnlineShop.Db.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
            ProductInOrders = new HashSet<ProductInOrder>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint TypeId { get; set; }
        public uint ManufacturerId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public sbyte Status { get; set; }
        public decimal Rating { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductType Type { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
