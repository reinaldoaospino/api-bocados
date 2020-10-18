using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using Infraestructure.Entities;

namespace api_bocados.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AuthUserEntity, AuthUser>().ReverseMap();
            CreateMap<TokenRequestModel, TokenRequest>().ReverseMap();
            CreateMap<TokenResponseModel, TokenResponse>().ReverseMap();
        }
    }
}
