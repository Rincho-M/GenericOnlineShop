using GenericOnlineShop.Services;
using GenericOnlineShop.Models;
using GenericOnlineShop.Views.Catalog;
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

        public async Task<IActionResult> Product(string id)
        {
            var products = await _readWriteDbService.ReadProducts(id);
            var productModel = new ProductModel(id, products);
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
