using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.ViewModels;
using InvoiceManagement.Web.Extensions;
using InvoiceManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model,string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Home");

            var result = await _userService.SignInAsync(model);

            if(result.Succeeded)
            {
                return Redirect(returnUrl);
            }

            ModelState.AddModelErrorList(result.Errors);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}