using System;
using System.Collections.Generic;

#nullable disable

namespace GenericOnlineShop.Models
{
    public partial class ProductImage
    {
        public uint Id { get; set; }
        public string Link { get; set; }
        public uint ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
