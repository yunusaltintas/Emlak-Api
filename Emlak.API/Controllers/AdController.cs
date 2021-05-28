using AutoMapper;
using Emlak.Data.DTOs;
using Emlak.Data.Entities;
using Emlak.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Emlak.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class AdController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementService _advertisementService;

        public AdController(IMapper mapper, IAdvertisementService advertisementService)
        {
            _mapper = mapper;
            _advertisementService = advertisementService;
        }

        [HttpGet]
        [Route("ad")]
        public IActionResult Gel()
        {
            IEnumerable<Claim> Claims = User.Claims;

            int UserId = int.Parse(Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value);
            string asgds = Claims.Where(x => x.Type == ClaimTypes.Email).First().Value;
            string dfgdfg = Claims.Where(x => x.Type == ClaimTypes.Name).First().Value;
            return Ok(UserId);
        }
    }
}
