using AutoMapper;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Repositories;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.UnitOfWorks;
using InvoiceManagement.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task ChangeAvaibleStatus(int id, bool isAvaible)
        {
            var apartment = await _repository.GetByIdAsync(id);
            apartment.IsAvailable = isAvaible;
            _repository.Update(apartment);
            await _unitOfWork.CommitChangesAsync();
        }

        public async Task<bool> CreateAsync(ApartmentCreateViewModel viewModel)
        {

            var isApartmentExist = await _repository.AnyAsync(x=> x.ApartmentNumber == viewModel.ApartmentNumber && x.Block == viewModel.Block);

            if (isApartmentExist)
                return true;

            var apartment = _mapper.Map<Apartment>(viewModel);
            await _repository.AddAsync(apartment);

            await _unitOfWork.CommitChangesAsync();
            return false;
        }

        public async Task<List<ApartmentSelectionListViewModel>> GetApartmentSelectionListViewModels()
        {
            var apartments = await _repository.Where(x=> x.IsAvailable == true).ToListAsync();

            var viewModelList = _mapper.Map<List<ApartmentSelectionListViewModel>>(apartments);

            return viewModelList;
        }

        public async Task<List<ApartmentListViewModel>> GetApartmentsWithListViewModel()
        {
            var apartments = await _repository.GetApartments();

            var apartmentListViewModel = _mapper.Map<List<ApartmentListViewModel>> (apartments);

            return apartmentListViewModel;
        }
    }
}
