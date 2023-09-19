using CubosBankAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Account : BaseEntity
    {
        public string OwnerId { get; private set; }
        public string Number { get; private set; }
        public string Branch { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string number, string branch, string ownerId)
        {
            Validations(number, branch, ownerId);
            this.Balance = 0;
        }

        private void Validations(string number, string branch, string ownerId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(number), "Number is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(branch), "Branch is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(ownerId), "OwnerId is mandatory.");

            Number = number;
            Branch = branch;
            OwnerId = ownerId;
        }   
    }
}
