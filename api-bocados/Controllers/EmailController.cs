using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;

namespace api_bocados.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailManager _emailManager;
        private readonly IMapper _mapper;

        public EmailController(IEmailManager emailManager, IMapper mapper)
        {
            _emailManager = emailManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("send")]
        public IActionResult GetToken(EmailRequestModel request)
        {
            var email = _mapper.Map<Email>(request);
            _emailManager.SendEmail(email);

            return Ok();
        }
    }
}
