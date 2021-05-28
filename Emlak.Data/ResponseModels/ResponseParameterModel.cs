using Emlak.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.ResponseModel
{
    public class ResponseParameterModel<TEntity> :BaseResponseModel
    {
        public TEntity Model { get; set; }
        public ResponseParameterModel(TEntity model)
        {
            this.Model = model;
            this.Success = true;
            
        }

        public ResponseParameterModel(string errorMassage)
        {
            this.Success = false;
            this.ErrorMessage = errorMassage;
        }
    }
}
