using CubosBankAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<ICollection<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id); 
    }
}
