﻿using CubosBankAPI.Domain.Entities;
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

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Number).HasColumnName("number").HasMaxLength(20).IsRequired();
            builder.Property(x => x.CVV).HasColumnName("security_code").HasMaxLength(3).IsRequired();
            builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.Cards).HasForeignKey(x => x.AccountId);
            builder.HasOne(x => x.Person).WithMany(x => x.Cards).HasForeignKey(x => x.PersonId);        
        }
    }
    
}
