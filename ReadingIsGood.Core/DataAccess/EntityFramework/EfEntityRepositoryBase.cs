using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace ReadingIsGood.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext : DbContext,new()
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public EfEntityRepositoryBase()
        {
            _context = new TContext();
            _dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
           
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
           
            _context.SaveChanges();
        }
        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression = null)
        {
            return filterExpression == null ?
                  _dbSet.AsQueryable<TEntity>().ToList():
                  _dbSet.Where(filterExpression).ToList();

        }

        public ICollection<TEntity> GetAll(int currentPage, int dataCountOfPage, Expression<Func<TEntity, bool>> filterExpression = null)
        {
            return filterExpression == null ?
                  _dbSet.AsQueryable<TEntity>()
                  .Skip((currentPage-1)*dataCountOfPage)
                  .Take(dataCountOfPage)
                  .ToList() :

                  _dbSet.Where(filterExpression)
                  .Skip((currentPage-1) * dataCountOfPage)
                  .Take(dataCountOfPage)
                  .ToList();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _dbSet.SingleOrDefault(filterExpression);
        }
        
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
           
            _context.SaveChanges();
        }

        
    }
}
