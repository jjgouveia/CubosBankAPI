using CubosBankAPI.Domain.Entities;
using CubosBankAPI.Domain.Repositories;
using CubosBankAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CubosBankDbContext _context;

        public TransactionRepository(CubosBankDbContext db)
        {
            _context = db;
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
