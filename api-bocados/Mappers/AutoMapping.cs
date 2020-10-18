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
            CreateMap<ProductModel, Product>().ReverseMap();
            //CreateMap<string, bool>().ConvertUsing(s => bool.Parse(s));
            CreateMap<Product, ProductEntity>().ReverseMap();
            CreateMap<AuthUserEntity, AuthUser>().ReverseMap();
            CreateMap<TokenRequestModel, TokenRequest>().ReverseMap();
            CreateMap<TokenResponseModel, TokenResponse>().ReverseMap();
        }
    }

}

     //.ForMember(s => s.IsFoo, opt => opt.ReadAsBoolean("IsFoo"))
