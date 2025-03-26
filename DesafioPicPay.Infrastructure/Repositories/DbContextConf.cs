using DesafioPicPay.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infrastructure.Repositories;

public class DbContextConf: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public DbContextConf() { }

    public DbContextConf(DbContextOptions<DbContextConf> options) 
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextConf).Assembly);

        foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationShip.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=postgres;Host=localhost;Port=5432;Database=DB01;User Id=app01;Password=321ca");
    }
}