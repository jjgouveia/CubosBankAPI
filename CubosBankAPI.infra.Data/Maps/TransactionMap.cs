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
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
            builder.Property(x => x.Value).HasColumnName("amount").IsRequired();
            builder.Property(x => x.CardType).HasColumnName("type").IsRequired();
            builder.Property(x => x.Date).HasColumnName("date").IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountId);
            builder.HasOne(x => x.Person).WithMany(x => x.Transactions).HasForeignKey(x => x.PersonId);
        }       

    }
}
