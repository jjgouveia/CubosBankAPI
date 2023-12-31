﻿using CubosBankAPI.Domain.Entities;

namespace CubosBankAPI.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(Guid id);
        Task<ICollection<Person>> GetPeopleAsync();
        Task<Person> CreateAsync(Person person);
        Task EditAsync(Person person);
        Task DeleteAsync(Person person);
        Task<bool> DocumentExists(string document);
    }
}
