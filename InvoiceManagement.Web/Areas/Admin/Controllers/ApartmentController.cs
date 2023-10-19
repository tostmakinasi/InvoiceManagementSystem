using AutoMapper;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _service;
   

        public ApartmentController(IApartmentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ApartmentList()
        {
            var apartments = await _service.GetApartmentsWithListViewModel();

            return View(apartments);
        }
    }
}
