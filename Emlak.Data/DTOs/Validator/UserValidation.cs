using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.DTOs.Validator
{
    public class UserValidation : AbstractValidator<CreateUserDTO>
    {
        public UserValidation()
        {
            RuleFor(o => o.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(o => o.Password).NotEmpty().NotNull();
            RuleFor(o => o.FirstName).NotEmpty().NotNull();
            RuleFor(o => o.SurName).NotEmpty().NotNull();
            RuleFor(o => o.UserName).NotEmpty().NotNull();
        }
    }
}
