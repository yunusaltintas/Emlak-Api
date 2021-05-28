using Emlak.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAdvertisementRepository AdvertisementRepository { get; }

        Task CommitAsync();
        void Commit();
    }
}
