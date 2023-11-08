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
            var userList = await _userService.GetUserViewModelList();

            return View(userList);
        }

        public async Task<IActionResult> PreRegistration()
        {
            ViewBag.apartments =  new SelectList(await _apartmentService.GetApartmentSelectionListViewModels(), nameof(ApartmentSelectionListViewModel.Id),nameof(ApartmentSelectionListViewModel.AparmnentAddress));
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PreRegistration(UserPreRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userService.PreRegistration(model);

            if (result.Succeeded)
            {
                string registrationLink = Url.Action("AccountCompletion", "Home", new { Area="", userId = result.Data.Id, Token = result.Data.Token }, HttpContext.Request.Scheme); 

                await _emailService.SendAccountCompletionEmail(registrationLink, model.Email);

                TempData["SuccessMessage"] = "Üye Ön Kaydı başarıyla gerçekleşmiştir.";
                return RedirectToAction(nameof(UsersController.PreRegistration));
            }

            ModelState.AddModelErrorList(result.Errors);
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteUser(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
