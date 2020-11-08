using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IEmailManager
    {
        void SendEmail(Email email);
    }
}
