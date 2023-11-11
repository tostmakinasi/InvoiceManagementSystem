using InvoiceManagement.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IUserService _userService;

        public MembersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task LogOutAsync()
        {
            await _userService.SignOutAsync();
        }
    }
}
