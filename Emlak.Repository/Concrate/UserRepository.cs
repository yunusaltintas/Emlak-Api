using Emlak.Data;
using Emlak.Data.Entities;
using Emlak.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Repository.Concrate
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EmlakDbContext Context) : base(Context)
        {
        }

        public async Task<User> GetUserByRefreshToken(string RefreshToken)
        {
            return await _context.Users.Where(x => x.RefreshToken == RefreshToken).SingleOrDefaultAsync();

        }
    }
}
