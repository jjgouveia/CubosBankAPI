using CubosBankAPI.Application.DTOs;
using CubosBankAPI.Application.DTOs.ResponseDTO;
using CubosBankAPI.Application.DTOs.Validations;
using CubosBankAPI.Application.Services.Interfaces;
using CubosBankAPI.Domain.Entities;
using CubosBankAPI.Domain.Repositories;

namespace CubosBankAPI.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTOResponse> CreatePerson(Person person)
        {
            if(person == null)
            {
                throw new NullReferenceException("A requisição não pode ser nula ou vazia.");
            }

            PersonDTO personDTO = new(person.Name, person.Document, person.Password);

            var validator = new PersonDTOValidator().Validate(personDTO);

            if (!validator.IsValid)
            {
                throw new Exception(string.Join(". ", validator.Errors.Select(x => x.ErrorMessage)));
            }

            bool documentExists = await _personRepository.DocumentExists(person.Document);
            if (documentExists)
            {
                  throw new Exception("Documento já cadastrado.");
            }


            Person personCreated = await _personRepository.CreateAsync(new(person.Name, person.Document, person.Password));

            PersonDTOResponse personCreatedDTO = new(personCreated.Id, personCreated.Name, personCreated.Document, personCreated.CreatedAt, personCreated.UpdatedAt);

            return personCreatedDTO;

        }

        public Task DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetPersonByDocument(string document)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> UpdatePerson(PersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
