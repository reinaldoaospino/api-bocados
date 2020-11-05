using System;
using Domain.Entities;
using System.Threading.Tasks;
using Domain.Interfaces.Application;

namespace Application.Managers
{
    public class EmailManager : IEmailManager
    {
        public Task SendEmail(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
