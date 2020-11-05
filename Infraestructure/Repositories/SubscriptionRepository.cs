using AutoMapper;
using Domain.Entities;
using System.Threading.Tasks;
using Infraestructure.Entities;
using Infraestructure.Interfaces;
using Domain.Interfaces.Infraestructure;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IMongoService _mogoService;
        private readonly IMapper _mapper;

        private readonly string _collectionName;

        public SubscriptionRepository(IMongoService mongoService,
            IConfiguration configuration, IMapper mapper)
        {
            _mogoService = mongoService;
            _mapper = mapper;
            _collectionName = configuration["AppSettings:subscriptionCollection"];
        }

        public Task Create(Subscription subscription)
        {
            var subscritionEntity = _mapper.Map<SubscriptionEntity>(subscription);
            return _mogoService.Create(_collectionName, subscritionEntity);
        }
    }
}
