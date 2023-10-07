
using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.ViewModels;
using System.Linq.Expressions;

namespace InvoiceManagement.Core.Services
{
    public interface IService<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> items);
    }
}
