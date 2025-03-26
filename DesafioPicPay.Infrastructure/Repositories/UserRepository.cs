using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Models;
using Microsoft.Extensions.Logging;

namespace DesafioPicPay.Infrastructure.Repositories
{
    public class UserRepository(DbContextConf contextConf, ILogger<UserRepository> logger) 
        : Repository<User>(contextConf, logger), IUserRepository
    {
    }
}
