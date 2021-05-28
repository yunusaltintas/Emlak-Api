using Emlak.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Repository.Abstract
{
    public interface IUserRepository:IBaseRepository<User>
    {

        Task<User> GetUserByRefreshToken(string RefreshToken);
    }
}
