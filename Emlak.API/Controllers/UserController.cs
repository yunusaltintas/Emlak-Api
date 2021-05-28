using AutoMapper;
using Emlak.Data.DTOs;
using Emlak.Data.Entities;
using Emlak.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emlak.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("user")]
        public IActionResult gel()
        {

            return Ok();
        }
    }
}
