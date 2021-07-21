using GenericOnlineShop.Services;
using GenericOnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericOnlineShop.Extensions;

namespace GenericOnlineShop.Controllers
{
    public class CatalogController : Controller
    {
        private const string CartKey = "cart";
        private readonly IReadWriteDbService _readWriteDbService;

        public CatalogController(IReadWriteDbService readWriteDbService)
        {
            _readWriteDbService = readWriteDbService;
        }

        public async Task<IActionResult> Product(string productTypeName)
        {
            Console.WriteLine("int catalog/product : " + productTypeName);
            var products = await _readWriteDbService.ReadProducts(productTypeName);
            var productModel = new ProductModel(productTypeName, products);
            return View(productModel);
        }

        [HttpPost]
        public async Task AddToCart([FromBody] ToCartRequestModel model)
        {
            Console.WriteLine("Add to cart method shitting ");
            var cart = HttpContext.Session.GetList<uint>(CartKey);
            cart.Add((uint)model.Id);
            cart.ForEach(p => Console.WriteLine("ProductId in cart: " + p));
            HttpContext.Session.SetList(CartKey, cart);
        }
    }
}
