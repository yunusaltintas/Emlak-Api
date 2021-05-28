using Emlak.Data.Entities;
using Emlak.Data.ResponseModel;
using Emlak.Data.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.Abstract
{
    public interface ITokenHandlerService
    {
        Task<ResponseParameterModel<AccessToken>> CreateAccessTokenAsync(User user);

        Task<ResponseParameterModel<AccessToken>> RevokeRefreshTokenAsync(User user);

        Task<ResponseParameterModel<AccessToken>> CreateAccessTokenByRefreshTokenAsync(string RefreshToken);
    }
}
