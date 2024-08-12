using DesafioPicPay.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPicPay.Infrastructure.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(c => c.AccountId);

            builder.Property(c => c.CostumerName)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(c => c.UpdateDate)
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(c => c.Active)
                .IsRequired();

            builder.Property(c => c.Balance)
                .IsRequired()
                .HasColumnType("decimal");

            //builder.HasOne(c => c.User)
            //    .WithOne(x => x.Account)
            //    .HasForeignKey<User>(x => x.UserId);


            builder.ToTable("Accounts");
        }
    }
}
