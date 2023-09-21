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
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("cards");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Number).IsUnique();


            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Number).HasColumnName("number").HasMaxLength(20).IsRequired();
            builder.Property(x => x.CVV).HasColumnName("cvv").HasMaxLength(3).IsRequired();
            builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(x => x.CardType).HasColumnName("card_type").IsRequired();
            builder.Property(x => x.Balance).HasColumnName("balance").IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.Cards).HasForeignKey(x => x.AccountId);
        }
    }
    
}
