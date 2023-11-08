using AutoMapper;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvoiceManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _service;
        private readonly IHouseTypeService _houseTypeService;

        public ApartmentController(IApartmentService service, IHouseTypeService houseTypeService)
        {
            _service = service;
            _houseTypeService = houseTypeService;
        }

        public async Task<IActionResult> ApartmentList()
        {
            var apartments = await _service.GetApartmentsWithListViewModel();

            return View(apartments);
        }

        private async Task<SelectList> GetHouseTypesAsSelectListAsync()
        {
            var selectList = new SelectList(await _houseTypeService.GetHouseTypes(), nameof(HouseTypeViewModel.Id), nameof(HouseTypeViewModel.Name));

            return selectList;
        }
        
        public async Task<IActionResult> Create()
        {
            ViewBag.houseTypes = await GetHouseTypesAsSelectListAsync(); 

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApartmentCreateViewModel apartment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.houseTypes = await GetHouseTypesAsSelectListAsync();

                return View();
            }

            var isApartmentExist =  await _service.CreateAsync(apartment);

            if (isApartmentExist)
            {
                ModelState.AddModelError(string.Empty, $"Girilen Daire daha önce eklenmiştir.");

                ViewBag.houseTypes = await GetHouseTypesAsSelectListAsync();
                return View();
            }

            return RedirectToAction(nameof(ApartmentList));
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(id);
            TempData["SuccessMessage"] = "Daire Başarıyla Silindi";
            return RedirectToAction(nameof(ApartmentList));
        }
    }
}
