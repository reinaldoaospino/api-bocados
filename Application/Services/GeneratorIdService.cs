using Domain.Interfaces.Application;
using System;

namespace Application.Services
{
    public class GeneratorIdService : IGeneratorIdService
    {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
