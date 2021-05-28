using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Repository
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        Task<TEntity> TAddAsync(TEntity entity);
        void TUpdate(TEntity entity);
        void TRemove(TEntity entity);
        Task<TEntity> TGetByIdAsync(int id);
        Task<List<TEntity>> TGetAllAsync();
        IQueryable<TEntity> TQuery();
        Task<TEntity> TFetchSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> TFindAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity LastRecord();


    }
}
