using Emlak.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Repository.Concrate
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly EmlakDbContext _context;
        private readonly DbSet<TEntity> _db;

        public BaseRepository(EmlakDbContext Context)
        {
            _context = Context;
            _db = _context.Set<TEntity>();
        }

        public async Task<TEntity> TAddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> TFetchSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.SingleOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> TFindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Where(predicate).ToListAsync();
             
        }

        public async Task<List<TEntity>> TGetAllAsync()
        {
            return await _db.ToListAsync();
        }   

        public async Task<TEntity> TGetByIdAsync(int id)
        {
            return await _db.FindAsync(id);
        }

        public IQueryable<TEntity> TQuery()
        {
            return _db.AsQueryable();
        }

        public void TRemove(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void TUpdate(TEntity entity)
        {
            _db.Update(entity);
        }

        public TEntity LastRecord()
        {

            return _db.ToList().LastOrDefault();
        }
    }
}
