using ReadingIsGood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        T Get(Expression<Func<T,bool>> filterExpression);
        ICollection<T> GetAll(Expression<Func<T, bool>> filterExpression = null);
        ICollection<T> GetAll(int currentPage, int dataCountOfPage,Expression<Func<T, bool>> filterExpression = null);
        void Update(T entity);
        void Delete(T entity);
    }
}
