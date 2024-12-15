using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using vetFoodShop.Order.Application.Interfaces;

namespace vetFoodShop.Order.Persistence.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
