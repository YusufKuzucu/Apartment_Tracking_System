using Apartment_Tracking_System.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Interfaces
{
    public interface IBaseRepository<T> where T :class,IEntity,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }

}
