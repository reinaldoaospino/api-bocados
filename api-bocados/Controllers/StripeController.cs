using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;

namespace api_bocados.Controllers
{
    [Route("api/stripe")]
    [ApiController]
    [Authorize]
    public class StripeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStripeManager _manager;

        public StripeController(IStripeManager manager, IMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentModel request)
        {
            var payment = _mapper.Map<Payment>(request);

            await _manager.CreatePayment(payment);

            return Ok();
        }
    }
}