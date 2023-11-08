using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Repositories;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvoiceManagement.Services.Services
{
    public class Service<T> : IService<T> where T : BaseModel
    {
        private readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items)
        {
            await _repository.AddRangeAsync(items);
            await _unitOfWork.CommitChangesAsync();

            return items;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasData = await _repository.GetByIdAsync(id);

            return hasData;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Remove(entity);
            await _unitOfWork.CommitChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> items)
        {
            _repository.RemoveRange(items);
            await _unitOfWork.CommitChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitChangesAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}

