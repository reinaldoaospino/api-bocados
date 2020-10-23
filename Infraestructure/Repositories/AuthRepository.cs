using AutoMapper;
using Domain.Entities;
using System.Threading.Tasks;
using Infraestructure.Entities;
using Infraestructure.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces.Infraestructure;

namespace Infraestructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoService _mongoService;
        private readonly IMapper _mapper;

        private readonly string _collectionName;

        public AuthRepository(IMongoService mongoService,
            IConfiguration configuration, IMapper mapper)
        {
            _mongoService = mongoService;
            _mapper = mapper;
            _collectionName = configuration["AppSettings:authUserCollection"];
        }

        public async Task<IEnumerable<AuthUser>> GetAuthUser()
        {
            var authUserEntity = await _mongoService.Get<AuthUserEntity>(_collectionName);

            var autUser = _mapper.Map<IEnumerable<AuthUser>>(authUserEntity);

            return autUser;
        }

        public async Task Create(AuthUser authUser)
        {
            var authUserEntity = _mapper.Map<AuthUserEntity>(authUser);

            await _mongoService.Create(_collectionName, authUserEntity);
        }
    }
}