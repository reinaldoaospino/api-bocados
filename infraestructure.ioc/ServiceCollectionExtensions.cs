using System;
using System.Text;
using Application;
using MongoDB.Driver;
using Infraestructure;
using Application.Managers;
using Application.Services;
using Infraestructure.Interfaces;
using Infraestructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infraestructure.ioc
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureApplicationModule(services);
            ConfigureJwtToken(services, configuration);
            ConfigureInfraestructureModule(services, configuration);
        }

        private static void ConfigureApplicationModule(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IGeneratorIdService, GeneratorIdService>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IEmailManager, EmailManager>();
            services.AddScoped<ISubscriptionManager, SubscriptionManager>();
        }

        public static void ConfigureInfraestructureModule(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["AppSettings:connectionString"];
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            services.AddScoped<IMongoService>(provider => new MongoService("Bocados", new MongoClient(connectionString)));         
        }

        private static void ConfigureJwtToken(IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["AppSettings:SecretKey"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";


            }).AddJwtBearer("JwtBearer", JwtBearerOptions =>
            {
                JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
        }
    }
}
