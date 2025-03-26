using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Models;
using Microsoft.Extensions.Logging;

namespace DesafioPicPay.Infrastructure.Repositories
{
    public class AccountRepository (DbContextConf contextConf, ILogger<AccountRepository> logger)
        : Repository<Account>(contextConf, logger), IAccountRepository
    {
    }
}
