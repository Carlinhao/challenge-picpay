using DesafioPicPay.Core.Dtos.Request;
using DesafioPicPay.Core.Dtos.Responses;
using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Interfaces.Services;
using DesafioPicPay.Infrastructure.MessageBus;
using DesafioPicPay.Infrastructure.Repositories;
using DesafioPicPay.Service.User;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioPicPay.Infrastructure.IoC
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection GetService(this IServiceCollection services)
        {
            services.AddDbContext<DbContextConf>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IEventBus, RabbitMqConfiguration>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<IUserService<UserRequest, UserResponse>, UserService>();

            return services;
        }
    }
}
