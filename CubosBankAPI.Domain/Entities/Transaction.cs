using CubosBankAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Domain.Entities
{
    public sealed class Transaction : BaseEntity
    {
        public string AccountId { get; private set; }
        public string CardId { get; private set; }
        public string PersonId { get; private set; }
        public decimal Value { get; private set; }
        public CardType CardType { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public Account Account { get; set; }
        public Card Card { get; set; }
        public Person Person { get; set; }

        public Transaction(string accountId, string cardId, decimal value, string description)
        {
            Validations(accountId, cardId, value, description);
            Date = DateTime.Now;
        }

        private void Validations(string accountId, string cardId, decimal value, string description)
        {
            DomainValidationException.When(string.IsNullOrEmpty(accountId), "AccountId is mandatory.");
            DomainValidationException.When(string.IsNullOrEmpty(cardId), "CardId is mandatory.");
            DomainValidationException.When(value <= 0, "Value must be higher than 0");
            DomainValidationException.When(string.IsNullOrEmpty(description), "Description is mandatory.");


            AccountId = accountId;
            CardId = cardId;
            Value = value;
            Description = description;
        }
    }
}
