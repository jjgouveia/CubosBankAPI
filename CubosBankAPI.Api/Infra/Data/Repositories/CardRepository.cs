using CubosBankAPI.Domain;
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
    public class CardRepository : ICardRepository
    {
        private readonly CubosBankDbContext _context;
        public CardRepository(CubosBankDbContext db)
        {
            _context = db;
        }

        public async Task<Card> CreateAsync(Card card)
        {
            _context.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

     

        public async Task DeleteAsync(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Card>> GetAllAsync()
        {
           return await _context.Cards.ToListAsync();
        }

        public Task<Card> GetByIdAsync(Guid id)
        {
            return _context.Cards.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<bool> GetPhysicalCardsByAccountIdAsync(Guid accountId)
        {
            return _context.Cards.AnyAsync(x => x.AccountId == accountId && x.CardType == "physical");
        }
    }
}
