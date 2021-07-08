using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Models
{
    public class CartModel
    {
        public IEnumerable<Product> Products { get; set; }

        public CartModel(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
