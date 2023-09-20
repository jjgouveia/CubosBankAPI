using CubosBankAPI.Application.DTOs;
using CubosBankAPI.Application.DTOs.ResponseDTO;
using CubosBankAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTOResponse> CreatePerson(Person person);
        Task<PersonDTO> GetPersonById(int id);
        Task<PersonDTO> GetPersonByDocument(string document);
        Task<PersonDTO> UpdatePerson(PersonDTO person);
        Task DeletePerson(int id);
    }
}
