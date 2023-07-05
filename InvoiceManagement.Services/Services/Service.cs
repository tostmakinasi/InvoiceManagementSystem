using AutoMapper;
using InvoiceManagement.Core.DTOs;
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Repositories;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvoiceManagement.Services.Services
{
    public class Service<Entity, Dto> : IService<Entity, Dto> where Entity : BaseModel where Dto : class
    {
        private readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public Service(IGenericRepository<Entity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(Dto dto)
        {
            var entity = _mapper.Map<Entity>(dto);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitChangesAsync();

            var newDto = _mapper.Map<Dto>(entity);
            return CustomResponseDto<Dto>.Success(StatusCodes.Status201Created, newDto);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtoList)
        {
            var entityList = _mapper.Map<IEnumerable<Entity>>(dtoList);

            await _repository.AddRangeAsync(entityList);
            await _unitOfWork.CommitChangesAsync();

            var newDtoList = _mapper.Map<IEnumerable<Dto>>(entityList);
            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status201Created, newDtoList);
        }

        public async Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var result = await _repository.AnyAsync(expression);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, result);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {
            var entityList = await _repository.GetAll().ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Dto>>(entityList);
            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtoList); ;
        }
        public async Task<CustomResponseDto<Dto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<Dto>(entity);

            return CustomResponseDto<Dto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Remove(entity);
            await _unitOfWork.CommitChangesAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<int> idList)
        {
            var entityList = await _repository.Where(x => idList.Contains(x.Id)).ToListAsync();

            _repository.RemoveRange(entityList);
            await _unitOfWork.CommitChangesAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(Dto dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            _repository.Update(entity);
            await _unitOfWork.CommitChangesAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression)
        {
            var entityList = await _repository.Where(expression).ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Dto>>(entityList);
            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtoList);
        }

    }
}
