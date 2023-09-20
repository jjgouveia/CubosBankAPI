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
    public class AccountRepository : IAccountRepository
    {
        private readonly CubosBankDbContext _context;

        public AccountRepository(CubosBankDbContext db)
        {
            _context = db;
        }

        public async Task<bool> AccountExists(string number)
        {
            return await _context.Accounts.AnyAsync(p => p.Number == number);
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _context.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAsync(Account account)
        {
           _context.Remove(account);
           await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public Task<List<Account>> GetAllByPeopleId(Guid personId)
        {
           return Task.FromResult(_context.Accounts.Where(p => p.PersonId == personId).ToList());
        }

        public async Task<decimal> GetBalance(Guid id)

        {
            var account = await _context.Accounts.FirstOrDefaultAsync(p => p.Id == id);

            return account == null ? throw new ArgumentNullException(id.ToString(), "Account not found.") : account.Balance;
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Account> GetByNumberAsync(string number)
        {
            if(string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException(number, "Number is mandatory.");
            }
            return await _context.Accounts.FirstOrDefaultAsync(p => p.Number == number);
        }
    }
}
