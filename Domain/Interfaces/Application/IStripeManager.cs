using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IStripeManager
    {
        Task CreatePayment(Payment payment);
    }
}
