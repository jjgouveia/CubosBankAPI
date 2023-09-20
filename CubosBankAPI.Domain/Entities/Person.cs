using CubosBankAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Person : BaseEntity
    {
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Password { get; private set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Person(string name, string document, string password)
        {
            Validations(name, document, password);
            Accounts = new List<Account>();
            Cards = new List<Card>();
            Transactions = new List<Transaction>();
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
