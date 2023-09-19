﻿using CubosBankAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Account : BaseEntity
    {
        public string PersonId { get; private set; }
        public string Number { get; private set; }
        public string Branch { get; private set; }
        public decimal Balance { get; private set; }
        public Person Person { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Account(string number, string branch, string personId)
        {
            Validations(number, branch, personId);
            this.Balance = 0;
        }

        private void Validations(string number, string branch, string personId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(number), "Number is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(branch), "Branch is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(PersonId), "PersonId is mandatory.");

            Number = number;
            Branch = branch;
            PersonId = personId;
        }   
    }
}
