using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using Infraestructure.Entities;
using System;

namespace api_bocados.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<Product, ProductEntity>().ReverseMap();
            CreateMap<AuthUserEntity, AuthUser>().ReverseMap();
            CreateMap<TokenRequestModel, TokenRequest>().ReverseMap();
            CreateMap<TokenResponseModel, TokenResponse>().ReverseMap();

        }
    }

}

