using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_bocados.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController
    {

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("token")]
        //public async Task<IActionResult> GetToken(TokenRequestModel request)
        //{
        //    var tokenDto = _mapper.Map<TokenRequest>(request);
        //    var token = await _tokenManager.GetToken(tokenDto);
        //    var tokenReponse = _mapper.Map<TokenResponseModel>(token);

        //    return Ok(tokenReponse);
        //}


        //[HttpPost]
        //public async Task<IActionResult> CreateAuth(AuthUserModel authUserModel)
        //{
        //    var authUserDto = _mapper.Map<AuthUser>(authUserModel);
        //    await _tokenManager.Create(authUserDto);
        //    return Ok();
        //}
    }
}
