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
    public class PersonRepository : IPersonRepository
    {
        private readonly CubosBankDbContext _context;

        public PersonRepository(CubosBankDbContext db)
        {
            _context = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await _context.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }
    }
}
