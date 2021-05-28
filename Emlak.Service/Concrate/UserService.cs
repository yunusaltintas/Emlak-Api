using Emlak.Data.DTOs;
using Emlak.Data.Entities;
using Emlak.Data.ResponseModel;
using Emlak.Repository;
using Emlak.Service.Abstract;
using Emlak.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Service.Concrate
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IPaswordHashService _paswordHashService;

        public UserService(IUnitOfWork unitOfWork, IBaseRepository<User> baseRepository, IPaswordHashService paswordHashService) : base(unitOfWork, baseRepository)
        {
            _paswordHashService = paswordHashService;
        }

        public async Task<ResponseParameterModel<User>> CreateUserAsync(CreateUserDTO userdto)
        {
            var DecryptedPass = _paswordHashService.Encypte(userdto.Password);
            if (DecryptedPass.Success == false || DecryptedPass == null)
            {
                return new ResponseParameterModel<User>("hata oluştu");
            }

            var user = new User
            {
                Email = userdto.Email,
                Password = DecryptedPass.Model.Text,
                UserName = userdto.UserName,
                FirstName = userdto.FirstName,
                SurName = userdto.SurName,
            };
            var newUser = await _unitOfWork.UserRepository.TAddAsync(user);
            await _unitOfWork.CommitAsync();

            if (newUser.Id == 0 || newUser == null)
            {
                return new ResponseParameterModel<User>("hata oluştu");
            }
            return new ResponseParameterModel<User>(newUser);

        }

        public async Task<ResponseParameterModel<User>> FindByIdAsync(int userId)
        {
            var GetUser= await _unitOfWork.UserRepository.TGetByIdAsync(userId);
            if (GetUser==null)
            {
                return new ResponseParameterModel<User>("hata oluştu.");
            }
            return new ResponseParameterModel<User>(GetUser);
        }

        public async Task<ResponseParameterModel<User>> FindEmailAndPasswordAsync(string email, string password)
        {
            //var GetUser = _unitOfWork.UserRepository.TFetchSingleAsync(x => x.Email == email).Result;
            //var GetUser = _unitOfWork.UserRepository.TQuery().Where(x => x.Email == email).SingleOrDefault();
            var GetUser =await _unitOfWork.UserRepository.TFetchSingleAsync(x => x.Email == email);
            if (GetUser == null)
            {
                return new ResponseParameterModel<User>("parola veya mail eşleşmedi");
            }
            var DecryptedPass= _paswordHashService.Decrypte(GetUser.Password);
            if (DecryptedPass.Success==false||DecryptedPass.Model==null)
            {
                return new ResponseParameterModel<User>("hata oluştu");
            }
            if (DecryptedPass.Model.Text!=password)
            {
                return new ResponseParameterModel<User>("parola veya mail eşleşmedi");
            }

            return new ResponseParameterModel<User>(GetUser);
        }

        public async Task<ResponseParameterModel<User>> GetUserWithRefreshTokenAsync(string refreshToken)
        {
            var GetUser= await _unitOfWork.UserRepository.TFetchSingleAsync(x => x.RefreshToken == refreshToken);
            if (GetUser == null)
            {
                return new ResponseParameterModel<User>("hata oluştu.");
            }
            return new ResponseParameterModel<User>(GetUser);

        }

        public void RemoveRefreshToken(User user)
        {
            throw new NotImplementedException();
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
