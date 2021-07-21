using GenericOnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.ViewComponents
{
    public class UserButtonViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new UserButtonModel();

            if(HttpContext.User.Identity.IsAuthenticated)
            {
                model.Name = HttpContext.User.Claims
                    .Where(c => c.Type == "name")
                    .Select(c => c.Value)
                    .FirstOrDefault();
                model.Link = "/account";
            }
            else
            {
                model.Name = "Sign In";
                model.Link = "";
            }

            return View(model);
        }
    }
}
