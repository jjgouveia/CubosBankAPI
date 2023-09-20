using CubosBankAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> CreateAsync(Account account);
        Task<ICollection<Account>> GetAllAsync();
        Task<decimal> GetBalance(Guid id);
        Task<Account> GetByNumberAsync(string number);
        Task<Account> GetByIdAsync(Guid id);
        Task EditAsync(Account account);
        Task DeleteAsync(Account account);
        Task<bool> AccountExists(string number);
    }
}
