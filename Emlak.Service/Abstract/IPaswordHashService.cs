using Emlak.Data.DTOs;
using Emlak.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Service.Abstract
{
    public interface IPaswordHashService
    {

        ResponseParameterModel<HashModel> Encypte(string Pasword);
        ResponseParameterModel<HashModel> Decrypte(string Pasword);
    }
}
