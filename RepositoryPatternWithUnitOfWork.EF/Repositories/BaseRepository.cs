using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // you can use arrow function if your implementation only 1 line
        public IEnumerable<T> GetAll() => _dbContext.Set<T>().ToList();

        public IEnumerable<T> GetAllWithIncludes(string[] includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            //_dbContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            //_dbContext.SaveChanges();
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            //await _dbContext.SaveChangesAsync();
            return entities;
        }

        public T Update(T entity)
        {
            _dbContext.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Attach(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
        }

        public int Count()
        {
            return _dbContext.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Count(expression);
        }
    }
}
