using DesafioPicPay.Core.Models;

namespace DesafioPicPay.Core.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task SaveAsync(T entity);
    Task<T> GetByIdAsync(string id);
}