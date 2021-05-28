using Emlak.Data.ResponseModel;
using Emlak.Data.ResponseModels;
using Emlak.Repository;
using Emlak.Service.Abstract;
using Emlak.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.Concrate
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IUnitOfWork unitOfWork,IBaseRepository<TEntity> baseRepository)
        {
            this._unitOfWork = unitOfWork;
            this._baseRepository = baseRepository;
        }

        public async Task<ResponseParameterModel<TEntity>> AddAsync(TEntity entity)
        {
            var result=await _baseRepository.TAddAsync(entity);
            await _unitOfWork.CommitAsync();

            if (result==null)
            {
                return new ResponseParameterModel<TEntity>("Hata oluştu.");
            }
            return new ResponseParameterModel<TEntity>(result);
        }

        public async Task<ResponseParameterModel<TEntity>> FetchSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _baseRepository.TFetchSingleAsync(predicate);
            if (result == null)
            {
                return new ResponseParameterModel<TEntity>("Hata oluştu.");
            }
            return new ResponseParameterModel<TEntity>(result);
        }

        public async Task<ResponseParameterModel<List<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _baseRepository.TFindAsync(predicate);
            if (result == null)
            {
                return new ResponseParameterModel<List<TEntity>>("Hata oluştu.");
            }
            return new ResponseParameterModel<List<TEntity>>(result);
        }

        public async Task<ResponseParameterModel<List<TEntity>>> GetAllAsync()
        {
            var result = await _baseRepository.TGetAllAsync();
            if (result == null)
            {
                return new ResponseParameterModel<List<TEntity>>("Hata oluştu.");
            }
            return new ResponseParameterModel<List<TEntity>>(result);

        }

        public async Task<ResponseParameterModel<TEntity>> GetByIdAsync(int id)
        {
            var result = await _baseRepository.TGetByIdAsync(id);
            if (result == null)
            {
                return new ResponseParameterModel<TEntity>("Hata oluştu.");
            }
            return new ResponseParameterModel<TEntity>(result);
        }

        public ResponseModel Remove(TEntity entity)
        {
            if (entity==null)
            {
                return new ResponseModel("hata oluştu.");
            }
            _baseRepository.TRemove(entity);
            _unitOfWork.Commit();
            return new ResponseModel();
        }

        public ResponseModel Update(TEntity entity)
        {
            if (entity == null)
            {
                return new ResponseModel("hata oluştu.");
            }
            _baseRepository.TUpdate(entity);
            _unitOfWork.Commit();
            return new ResponseModel();
        }
    }
}
