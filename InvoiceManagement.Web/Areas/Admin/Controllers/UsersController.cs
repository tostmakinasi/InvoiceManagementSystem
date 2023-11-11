using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.ViewModels;
using InvoiceManagement.Web.Controllers;
using InvoiceManagement.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace InvoiceManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IApartmentService _apartmentService;
        private readonly IEmailService _emailService;

        public UsersController(IUserService userService, IApartmentService apartmentService, IEmailService emailService)
        {
            _userService = userService;
            _apartmentService = apartmentService;
            _emailService = emailService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var userList = await _userService.GetUserViewModelListAsync();

            return View(userList);
        }

        public async Task<IActionResult> Registration()
        {
            ViewBag.apartments =  new SelectList(await _apartmentService.GetApartmentSelectionListViewModels(), nameof(ApartmentSelectionListViewModel.Id),nameof(ApartmentSelectionListViewModel.AparmnentAddress));
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userService.RegistrationAsync(model);

            if (result.Succeeded)
            {

                TempData["SuccessMessage"] = "Üye Ön Kaydı başarıyla gerçekleşmiştir.";
                return RedirectToAction(nameof(UsersController.Registration));
            }

            ModelState.AddModelErrorList(result.Errors);
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteUserAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
