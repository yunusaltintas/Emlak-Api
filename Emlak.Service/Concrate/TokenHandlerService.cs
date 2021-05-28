using Emlak.Data.Entities;
using Emlak.Data.Security;
using Emlak.Data.SystemOptionModels;
using Emlak.Service.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using Emlak.Service.IUnitOfWorks;
using System.Threading.Tasks;
using Emlak.Data.ResponseModel;

namespace Emlak.Service.Concrate
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly TokenOptions _tokenOptions;
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IUserService _userService;

        public TokenHandlerService(IOptions<TokenOptions> tokenOptions, IUnitOfWork unitOfWorks, IUserService userService)
        {
            _tokenOptions = tokenOptions.Value;
            _unitOfWorks = unitOfWorks;
            _userService = userService;
        }

        public async Task<ResponseParameterModel<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var AccessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var SecuityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

            SigningCredentials SigningCredential = new SigningCredentials(SecuityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken JwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: AccessTokenExpiration,
                claims: GetClaims(user),
                notBefore: DateTime.Now,
                signingCredentials: SigningCredential

                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(JwtSecurityToken);


            string GetRefreshToken = CreateRefreshToken();

            var AccessToken = new AccessToken()
            {
                Token = token,
                RefreshToken = GetRefreshToken,
                Expiration = AccessTokenExpiration
            };
            await UpdateUserRefreshTokenAndExpirationAsync(user.Id, GetRefreshToken, AccessTokenExpiration);

            if (AccessToken == null)
            {
                return new ResponseParameterModel<AccessToken>("hata oluştu");
            }
            return new ResponseParameterModel<AccessToken>(AccessToken);
        }

        public async Task<ResponseParameterModel<AccessToken>> RevokeRefreshTokenAsync(User user)
        {
            var User = await _unitOfWorks.UserRepository.GetUserByRefreshToken(user.RefreshToken);

            User.RefreshToken = null;
            User.RefreshTokenEndDate = null;
            _unitOfWorks.UserRepository.TUpdate(User);
            _unitOfWorks.Commit();

            return new ResponseParameterModel<AccessToken>(new AccessToken());
        }

        public async Task<ResponseParameterModel<AccessToken>> CreateAccessTokenByRefreshTokenAsync(string RefreshToken)
        {
            var getUser = await _userService.GetUserWithRefreshTokenAsync(RefreshToken);
            if (getUser.Success == false || getUser.Model == null)
            {
                return new ResponseParameterModel<AccessToken>("User bulunamadı.");
            }
            if (getUser.Model.RefreshTokenEndDate<DateTime.Now)
            {
                return new ResponseParameterModel<AccessToken>("refresh token süresi bitti");
            }

            var newToken = await CreateAccessTokenAsync(getUser.Model);
            if (newToken.Success == false || newToken.Model == null)
            {
                return new ResponseParameterModel<AccessToken>("hata oluştu.");
            }

            return new ResponseParameterModel<AccessToken>(newToken.Model);

        }

        private IEnumerable<Claim> GetClaims(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,$"{user.FirstName}{user.SurName}"),
                new Claim(JwtRegisteredClaimNames.Jti,System.Guid.NewGuid().ToString())
            };

            return claims;
        }

        private string CreateRefreshToken()
        {
            var NumberByte = new Byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(NumberByte);

                return Convert.ToBase64String(NumberByte);
            }
        }

        private async Task UpdateUserRefreshTokenAndExpirationAsync(int userId, string RefreshToken, DateTime Expiration)
        {

            var result = await _unitOfWorks.UserRepository.TGetByIdAsync(userId);
            result.RefreshToken = RefreshToken;
            result.RefreshTokenEndDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);

            _unitOfWorks.UserRepository.TUpdate(result);
            _unitOfWorks.Commit();

        }
    }
}
