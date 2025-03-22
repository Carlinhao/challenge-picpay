using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Models;
using Microsoft.Extensions.Logging;

namespace DesafioPicPay.Infrastructure.Repositories
{
    public class TransferRepository(DbContextConf dbContext, ILogger<TransferRepository> logger) 
        : Repository<Transfer>(dbContext, logger), ITransferRepository
    {
    }
}
