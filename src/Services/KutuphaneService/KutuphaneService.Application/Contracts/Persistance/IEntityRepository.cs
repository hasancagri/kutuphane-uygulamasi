using KutuphaneService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Contracts.Persistance
{
    public interface IEntityRepository<T>
         where T : EntityBase
    {
        Task<List<T>> GetList(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       bool disableTracking = true);
        Task<T> Get(Expression<Func<T, bool>> predicate,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       bool disableTracking = true);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
