﻿using CubosBankAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Account : BaseEntity
    {
        public Guid PersonId { get; private set; }
        public string Branch { get; private set; }
        public string Number { get; private set; }
        public decimal Balance { get; private set; }

        public Person Person { get; set; }
        public ICollection<Card> Cards { get; private set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Account(string branch, string number, Guid personId)
        {
            Validations(branch, number, personId);
            this.Balance = 0;
            Cards = new List<Card>();
            Transactions = new List<Transaction>();
        }

        private Account()
        {
            this.Balance = 0;
            Cards = new List<Card>();
            Transactions = new List<Transaction>();
        }

        private void Validations(string branch, string number, Guid personId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(branch), "Branch is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(number), "Number is mandatory.");
            DomainValidationException.When(personId == Guid.Empty, "PersonId is mandatory.");

            Branch = branch;
            Number = number;
            PersonId = personId;
        }

        //public void AssignPhysicalCard(Card card)
        //{
        //    if (Cards.Any(c => c.CardType == CardType.Physical))
        //    {
        //        throw new InvalidOperationException("Esta conta já possui um cartão físico.");
        //    }

        //    Cards.Add(card);
        //}
    }
}
