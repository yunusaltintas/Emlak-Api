using Emlak.Data;
using Emlak.Repository.Abstract;
using Emlak.Repository.Concrate;
using Emlak.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmlakDbContext _context;
        private UserRepository _userRepository;
        private AdvertisementRepository _advertisementRepository;

        public UnitOfWork(EmlakDbContext emlakDbContext)
        {
            _context = emlakDbContext;
        }

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);

        public IAdvertisementRepository AdvertisementRepository => _advertisementRepository = _advertisementRepository ?? new AdvertisementRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
