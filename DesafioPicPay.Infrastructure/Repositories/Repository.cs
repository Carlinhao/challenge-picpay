using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Models;

namespace DesafioPicPay.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    public Task SaveAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}