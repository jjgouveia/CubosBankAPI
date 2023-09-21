using CubosBankAPI.Domain.Validations;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Card : BaseEntity
    {
        public CardType CardType { get; set; }
        public string Number { get; private set; }
        public string CVV { get; private set; }
        public Guid AccountId { get; set; }
        public decimal Balance { get; private set; }
        public Account Account { get; set; }

        private Card()
        {
            Balance = 0;
        }

        public Card(CardType cardType, string number, string cvv, Guid accountId)
        {
            Validations(number, cvv, cardType, accountId);
            Balance = 0;
        }

        private void Validations(string number, string cvv, CardType cardType, Guid accountId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(number), "Number is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(cvv), "CVV is mandatory.");
            DomainValidationException.When(accountId == Guid.Empty, "AccountId is mandatory.");
            DomainValidationException.When(cardType != CardType.Physical && cardType != CardType.Virtual, "CardType must be 'Physical' or 'Virtual'.");



            Number = number;
            CVV = cvv;
            AccountId = accountId;
            CardType = cardType;
        }       

        public void Deposit(decimal value)
        {
            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (Balance < value)
                throw new Exception("Saldo insuficiente");

            Balance -= value;
        }   

        public void UpdateBalance(decimal value)
        {
            Balance += value;
        }   
    }
}
