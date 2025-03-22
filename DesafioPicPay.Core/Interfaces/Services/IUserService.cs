using System.Linq.Expressions;

namespace DesafioPicPay.Core.Interfaces.Services;

public interface IUserService<in TRequest, TResponse>
{
    Task AddAsync(TRequest request, CancellationToken cancellationToken);
    Task<TResponse> GetAsync(string id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<TResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<TResponse> Search(TRequest request, CancellationToken cancellationToken);
}