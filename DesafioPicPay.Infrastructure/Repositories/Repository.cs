using System.Linq.Expressions;
using DesafioPicPay.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioPicPay.Infrastructure.Repositories;

public abstract class Repository<T>(DbContextConf context, ILogger<Repository<T>> logger) : IRepository<T> where T : class
{
    private readonly ILogger<Repository<T>> _logger = logger;
    protected readonly DbContextConf Context = context;
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public async Task SaveAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            await DbSet.AddAsync(entity, cancellationToken);
            await SaveChanges(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.BeginScope(new Dictionary<string, object>()
            {
                ["Mensagem"] = ex.Message,
                ["Dados"] = ex.Data,
                ["Pilha de exceção"] = ex.StackTrace

            });

            throw;
        }
    }

    public async Task<T> GetByIdAsync(string value, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync([value], cancellationToken);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await SaveChanges(cancellationToken);
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken)
    {
        return await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> Search(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await DbSet.Where(predicate).SingleOrDefaultAsync(cancellationToken);
    }
}