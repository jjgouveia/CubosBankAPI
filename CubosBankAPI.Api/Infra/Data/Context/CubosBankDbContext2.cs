using CubosBankAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CubosBankAPI.Infra.Data.Context
{
    public class CubosBankDbContext : DbContext
    {
        public CubosBankDbContext(DbContextOptions<CubosBankDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CubosBankDbContext).Assembly);
        }
    }
}
