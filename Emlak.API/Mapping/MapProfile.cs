using AutoMapper;
using Emlak.Data.DTOs;
using Emlak.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emlak.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, CreateUserDTO>();
            CreateMap<CreateUserDTO, User>();

            CreateMap<Advertisement, AdvertisementDTO>();
            CreateMap<AdvertisementDTO, Advertisement>();
        }
    }
}
