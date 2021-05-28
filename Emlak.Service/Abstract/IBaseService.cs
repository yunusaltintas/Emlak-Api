using Emlak.Data.ResponseModel;
using Emlak.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.Abstract
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        Task<ResponseParameterModel<TEntity>> AddAsync(TEntity entity);
        ResponseModel Update(TEntity entity);
        ResponseModel Remove(TEntity entity);
        Task<ResponseParameterModel<TEntity>> GetByIdAsync(int id);
        Task<ResponseParameterModel<List<TEntity>>> GetAllAsync();
        Task<ResponseParameterModel<TEntity>> FetchSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ResponseParameterModel<List<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
