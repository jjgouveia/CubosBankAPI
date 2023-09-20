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
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
           builder.ToTable("people");
           builder.HasKey(x => x.Id);
           builder.HasIndex(u => u.Document).IsUnique();

           builder.Property(x => x.Id).HasColumnName("id");
           builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(128).IsRequired();
           builder.Property(x => x.Document).HasColumnName("document").HasMaxLength(20).IsRequired();
           builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(20).IsRequired();

           builder.HasMany(x => x.Accounts).WithOne(x => x.Person).HasForeignKey(x => x.PersonId);
           builder.HasMany(x => x.Cards).WithOne(x => x.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
