using GenericOnlineShop.Models;
using GenericOnlineShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GenericOnlineShop.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace GenericOnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IReadWriteDbService _readWriteDbService;

        public AccountController(
            IReadWriteDbService readWriteDbService)
        {
            _readWriteDbService = readWriteDbService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _readWriteDbService.FindUser(model);
                
                if(user != null)
                {
                    if(user.Password == model.Password)
                    {
                        // Here we know the user exist in the database.
                        var dbClaims = new List<Claim>()
                        {
                            new Claim("id", user.Id.ToString()),
                            new Claim("name", user.Name)
                        };
                        var dbIdentity = new ClaimsIdentity(dbClaims, "Db Identity");
                        var userPrincipal = new ClaimsPrincipal(new[] { dbIdentity });

                        await HttpContext.SignInAsync(userPrincipal);

                        return Json(user);
                    }

                    return Json(new { ErrorField = "password", ErrorText = "Incorrect password." });
                }

                return Json(new { ErrorField = "email", ErrorText = "User with this email doesn't exist." });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
