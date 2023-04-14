using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllWithIncludes(string[] includes = null);

        Task<IEnumerable<T>> GetAllAsync();

        T Find(Expression<Func<T, bool>> expression);

        Task<T> FindAsync(Expression<Func<T, bool>> expression);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression);

        T Add(T entity);

        Task<T> AddAsync(T entity);
       
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);

        void Delete(T entity);

        void Attach(T entity);

        int Count();
        int Count(Expression<Func<T, bool>> expression);
    }
}
