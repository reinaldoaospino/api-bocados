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
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<Product, ProductEntity>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<CategoryEntity, Category>().ReverseMap();
            CreateMap<EmailRequestModel, Email>().ReverseMap();
            CreateMap<AuthUserEntity, AuthUser>().ReverseMap();
            CreateMap<UserModelResponse, UserResponse>().ReverseMap();
            CreateMap<TokenRequestModel, TokenRequest>().ReverseMap();
            CreateMap<TokenResponseModel, TokenResponse>().ReverseMap();
        }
    }
}
