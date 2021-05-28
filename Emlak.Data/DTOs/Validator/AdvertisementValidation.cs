using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.DTOs.Validator
{
    public class AdvertisementValidation:AbstractValidator<AdvertisementDTO>
    {
        public AdvertisementValidation()
        {
            RuleFor(o => o.AdvertisementTitle).NotEmpty().NotNull().Length(0,450);
            RuleFor(o => o.BuildingAge).NotEmpty().NotNull();
            RuleFor(o => o.District).NotEmpty().NotNull().Length(0, 120);
            RuleFor(o => o.Explanation).NotEmpty().NotNull().Length(0, 1500);
            RuleFor(o => o.Price).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(o => o.Province).NotEmpty().NotNull().Length(0, 100);
            RuleFor(o => o.Room).NotEmpty().NotNull().Length(0, 10);
            RuleFor(o => o.SquareMeters).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(o => o.Status).NotEmpty().NotNull().Length(0, 100);

        }

    }
}
