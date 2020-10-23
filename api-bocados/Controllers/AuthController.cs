using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;

namespace api_bocados.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ITokenManager _tokenManager;
        private readonly IMapper _mapper;

        public AuthController(ITokenManager tokenManager, IMapper mapper)
        {
            _tokenManager = tokenManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> GetToken(TokenRequestModel request)
        {
            var tokenDto = _mapper.Map<TokenRequest>(request);
            var token = await _tokenManager.GetToken(tokenDto);
            var tokenReponse = _mapper.Map<TokenResponseModel>(token);

            return Ok(tokenReponse);
        }

    }
}
