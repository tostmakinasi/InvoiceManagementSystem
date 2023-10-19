using AutoMapper;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Repositories;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.UnitOfWorks;
using InvoiceManagement.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Services.Services
{
    public class ApartmentService : Service<Apartment>, IApartmentService
    {
        private readonly IApartmentRepository _repository;
        private readonly IMapper _mapper;
        public ApartmentService(IUnitOfWork unitOfWork, IApartmentRepository repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ApartmentListViewModel>> GetApartmentsWithListViewModel()
        {
            var apartments = await _repository.GetApartments();

            var apartmentListViewModel = _mapper.Map<List<ApartmentListViewModel>> (apartments);

            return apartmentListViewModel;
        }
    }
}
