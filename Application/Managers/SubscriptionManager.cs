using Domain.Entities;
using System.Threading.Tasks;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;

namespace Application.Managers
{
    public class SubscriptionManager : ISubscriptionManager
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IGeneratorIdService _generatorId;

        public SubscriptionManager(ISubscriptionRepository repository, IGeneratorIdService generatorId)
        {
            _repository = repository;
            _generatorId = generatorId;
        }

        public Task Create(Subscription subscription)
        {
            subscription.Id = _generatorId.GenerateId();

            return _repository.Create(subscription);
        }
    }
}
