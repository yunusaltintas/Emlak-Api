using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.ResponseModels
{
    public class ResponseModel: BaseResponseModel
    {
        public ResponseModel()
        {
            this.Success = true;
        }
        public ResponseModel(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Success = false;
        }

    }
}
