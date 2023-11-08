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
    public class HouseTypeService : Service<HouseType>, IHouseTypeService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<HouseType> _repository;

        public HouseTypeService(IUnitOfWork unitOfWork, IGenericRepository<HouseType> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<HouseTypeViewModel>> GetHouseTypes()
        {
            var houseTypes = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<HouseTypeViewModel>>(houseTypes);
        }
    }
}
