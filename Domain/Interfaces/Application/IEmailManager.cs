using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IEmailManager
    {
        Task SendEmail(Email email);
    }
}
