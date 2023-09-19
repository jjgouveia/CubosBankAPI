using CubosBankAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Password { get; private set; }

        public Person(string name, string document, string password)
        {
            Validations(name, document, password);
        }

        private void Validations(string name, string document, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Document is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password is mandatory.");

            Name = name;
            Document = document;
            Password = password;
        }   



        
    }
}
