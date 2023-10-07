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
        private readonly IService<Apartment> _service;
        private readonly IMapper _mapper;

        public ApartmentController(IService<Apartment> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> ApartmentList()
        {
            var apartments = await _service.GetAllAsync();

            var apartmentsViewModel = _mapper.Map<IEnumerable<ApartmentViewModel>>(apartments);

            return View(apartmentsViewModel);
        }
    }
}
