using GenericOnlineShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadWriteDbService _dbService;
        public HomeController(IReadWriteDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
