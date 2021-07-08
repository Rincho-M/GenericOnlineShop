using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericOnlineShop.Extensions;
using GenericOnlineShop.Services;
using GenericOnlineShop.Models;

namespace GenericOnlineShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartKey = "cart";
        private readonly IReadWriteDbService _readWriteDbService;

        public CartController(IReadWriteDbService readWriteDbService)
        {
            _readWriteDbService = readWriteDbService;
        }

        public async Task<IActionResult> Index()
        {
            Console.WriteLine("Index in Cart shitting ");
            var cart = HttpContext.Session.GetList<uint>(CartKey);
            Console.WriteLine(cart);
            var productsList = await _readWriteDbService.ReadProductsById(cart);
            var model = new CartModel(productsList);

            return View(model);
        }
    }
}
