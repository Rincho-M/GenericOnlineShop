using GenericOnlineShop.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Views.Catalog
{
    public class ProductModel
    {
        public string ProductName { get; private set; }
        public IEnumerable<Product> Products { get; private set; }

        public ProductModel(string productName, IEnumerable<Product> products)
        {
            ProductName = productName;
            Products = products;
        }
    }
}
