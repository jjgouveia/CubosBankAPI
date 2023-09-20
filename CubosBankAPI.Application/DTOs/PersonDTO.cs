using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs
{
    public class PersonDTO
    {
        public PersonDTO(string name, string document, string password)
        {
            Name = name;
            Document = document;
            Password = password;
        }

        //public PersonDTO(Guid id, string name, string document, string password)
        //{
        //    Id = id;
        //    Name = name;
        //    Document = document;
        //    Password = password;
        //}

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //internal static ActionResult BadRequest(string v)
        //{
        //    return new BadRequestObjectResult(v);
        //}

        //internal static string GetErrors(List<ValidationFailure> errors)
        //{
        //    return string.Join(", ", errors.Select(x => x.ErrorMessage));
        //}

        //internal static ActionResult Ok(PersonDTO person)
        //{
        //    return new OkObjectResult(person);
        //}
    }
}
