using Emlak.Data.DTOs;
using Emlak.Data.ResponseModel;
using Emlak.Service.Abstract;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Service.Concrate
{
    public class PaswordHashService : IPaswordHashService
    {
        private const string Key = "bu-aksam-olurum-beni-kimse-tutamaz";

        private readonly IDataProtectionProvider _dataProtectionProvider;
        public PaswordHashService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public ResponseParameterModel<HashModel> Encypte(string Pasword)
        {

            var EncryptedPassword = new HashModel();
            var protector = _dataProtectionProvider.CreateProtector(Key);
            EncryptedPassword.Text = protector.Protect(Pasword);
            if (EncryptedPassword.Text == null)
            {
                return new ResponseParameterModel<HashModel>("hata oluştu.");
            }
            return new ResponseParameterModel<HashModel>(EncryptedPassword);
        }

        public ResponseParameterModel<HashModel> Decrypte(string Pasword)
        {
            var DecryptedPassword = new HashModel();
            var protector = _dataProtectionProvider.CreateProtector(Key);
            DecryptedPassword.Text = protector.Unprotect(Pasword);
            if (DecryptedPassword.Text == null)
            {
                return new ResponseParameterModel<HashModel>("hata oluştu.");
            }
            return new ResponseParameterModel<HashModel>(DecryptedPassword);
        }
    }
}
