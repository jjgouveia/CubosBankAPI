﻿using CubosBankAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<Card> CreateAsync(Card card);
        Task<ICollection<Card>> GetAllAsync();
        Task<Card> GetByIdAsync(Guid id);
        Task DeleteAsync(int id);    
    }
}
