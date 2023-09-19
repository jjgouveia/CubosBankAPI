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
        public string Number { get; private set; }
        public string CVV { get; private set; }
        public decimal Balance { get; private set; }
        public string AccountId { get; private set; }
        public string PersonId { get; private set; }
        public CardType CardType { get; set; }
        public Account Account { get; set; }
        public Person Person { get; set; }

        public Card(CardType cardType, string number, string cvv, string accountId)
        {
            Validations(number, cvv, accountId, cardType);
            Balance = 0;
        }

        private void Validations(string number, string cvv, string accountId, CardType cardType)
        {
            DomainValidationException.When(string.IsNullOrEmpty(number), "Number is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(cvv), "CVV is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(accountId), "AccountId is mandatory.");
            DomainValidationException.When(Enum.IsDefined(typeof(CardType), cardType), "CardType is mandatory.");

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
