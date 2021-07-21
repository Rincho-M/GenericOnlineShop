using GenericOnlineShop.Models;
using GenericOnlineShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.ViewComponents
{
    public class CatalogNavigationViewComponent : ViewComponent
    {
        private readonly IReadWriteDbService _readWriteDbService;

        public CatalogNavigationViewComponent(IReadWriteDbService readWriteDbService)
        {
            _readWriteDbService = readWriteDbService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productTypes = await _readWriteDbService.Read();
            var data = productTypes.Select(t => t.Name);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            var model = new CatalogNavigationModel(data);

            return View(model);
        }
    }
}
