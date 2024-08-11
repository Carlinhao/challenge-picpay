using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Infrastructure.MessageBus;
using DesafioPicPay.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
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

            return services;
        }
    }
}
