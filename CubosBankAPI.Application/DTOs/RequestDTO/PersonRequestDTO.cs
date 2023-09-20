using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.RequestDTO
{
    public class PersonRequestDTO
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }

        public PersonRequestDTO(string name, string document, string password)
        {
            Name = name;
            Document = document;
            Password = password;
        }
    }
}
