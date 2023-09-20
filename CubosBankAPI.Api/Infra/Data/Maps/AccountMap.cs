using CubosBankAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Infra.Data.Maps
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Number).IsUnique();

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Branch).HasColumnName("branch").HasMaxLength(3).IsRequired();
            builder.Property(x => x.Number).HasColumnName("number").HasMaxLength(9).IsRequired();
            builder.Property(x => x.Balance).HasColumnName("balance").IsRequired();
            builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();

            builder.HasOne(x => x.Person).WithMany(x => x.Accounts).HasForeignKey(x => x.PersonId);
            builder.HasMany(x => x.Cards).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
        }
    }
}
