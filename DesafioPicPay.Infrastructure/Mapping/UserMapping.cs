using DesafioPicPay.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPicPay.Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.UserId);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Active)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.TypeUser)
                .IsRequired()
                .HasColumnType("char(1)");

            builder.HasOne(c => c.Account)
                .WithOne(x => x.User)
                .HasForeignKey<Account>(x => x.UserId);


            builder.ToTable("Users");
        }
    }
}
