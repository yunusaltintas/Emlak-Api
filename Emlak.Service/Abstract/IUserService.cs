using Emlak.Data.DTOs;
using Emlak.Data.Entities;
using Emlak.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        Task<ResponseParameterModel<User>> CreateUserAsync(CreateUserDTO userdto);

        Task<ResponseParameterModel<User>> FindByIdAsync(int userId);

        Task<ResponseParameterModel<User>> FindEmailAndPasswordAsync(string email, string password);

        void SaveRefreshToken(int userId, string refreshToken);

        Task<ResponseParameterModel<User>> GetUserWithRefreshTokenAsync(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}
