using AutoMapper;
using Emlak.Data.DTOs;
using Emlak.Data.Entities;
using Emlak.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Emlak.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IPaswordHashService _paswordHashService;
        private readonly ITokenHandlerService _tokenHandler;

        public AuthenticationController(IMapper mapper, IUserService userService, IPaswordHashService paswordHashService, ITokenHandlerService tokenHandler)
        {
            _mapper = mapper;
            _userService = userService;
            _paswordHashService = paswordHashService;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);

            if (result.Success == false || result.Model == null)
            {
                return BadRequest(result.ErrorMessage);
            }
            else
            {
                return Ok(result.Model);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var getUser = await _userService.FindEmailAndPasswordAsync(loginDTO.Email, loginDTO.Password);

            if (getUser.Success == false || getUser.Model == null)
            {
                return BadRequest(getUser.ErrorMessage);
            }

            var tokens = await _tokenHandler.CreateAccessTokenAsync(getUser.Model);
            if (tokens.Success == false || tokens.Model == null)
            {
                return BadRequest(tokens.ErrorMessage);
            }
            return Ok(tokens.Model);

        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> CreateTokenByRefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            var tokens = await _tokenHandler.CreateAccessTokenByRefreshTokenAsync(refreshTokenDTO.RefreshToken);
            if (tokens.Success==false||tokens.Model==null)
            {
                return BadRequest(tokens.ErrorMessage);
            }
            return Ok(tokens.Model);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> LogOutAsync()
        {
            IEnumerable<Claim> Claims = User.Claims;

            int UserId = int.Parse(Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value);
            var GetUser = await _userService.FindByIdAsync(UserId);

            if (GetUser.Success == false || GetUser.Model == null)
            {
                return BadRequest(GetUser.ErrorMessage);
            }

            await _tokenHandler.RevokeRefreshTokenAsync(GetUser.Model);

            return Ok();
        }


        [HttpPost]
        [Route("Forgot")]
        public IActionResult ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            Random Rnd = new Random();
            string Code = null;
            for (int i = 0; i < 6; i++)
            {
                string Number = Rnd.Next(0, 10).ToString();

                Code += Number;

            }

            //string Code = Guid.NewGuid().ToString().Substring(0, 6);
            return Ok(Code);
        }




    }
} 
