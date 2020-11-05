using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;

namespace api_bocados.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionManager _manager;
        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(SubscriptionModel subscriptionModel)
        {
            var subscription = _mapper.Map<Subscription>(subscriptionModel);
            await _manager.Create(subscription);
            return Ok();
        }
    }
}
