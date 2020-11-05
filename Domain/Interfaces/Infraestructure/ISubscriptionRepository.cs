using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Infraestructure
{
    public interface ISubscriptionRepository
    {
        Task Create(Subscription subscription);
    }
}
