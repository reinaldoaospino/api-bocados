using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;

namespace api_bocados.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserManager _manager;
        private readonly IMapper _mapper;

        public UserController(IUserManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(string id)
        {
            var user = await _manager.Get(id);
            var userModel = _mapper.Map<UserModel>(user);
            return Ok(userModel);
        }


        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<UserModelResponse>> Authenticate(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var response = await _manager.Authenticate(user);
            var responseDto = _mapper.Map<UserModelResponse>(response);
            return Ok(responseDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            await _manager.Create(user);
            return Ok();
        }
    }
}