using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.ResponseModels
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
