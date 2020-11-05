using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface ISubscriptionManager
    {
        Task Create(Subscription subscription);
    }
}
