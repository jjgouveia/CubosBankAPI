using CubosBankAPI.Domain;

namespace CubosBankAPI.Application.DTOs
{
    public class CardDTO
    {
        public CardDTO(CardType cardType, string number, string cVV)
        {
            CardType = cardType;
            Number = number;
            CVV = cVV;
        }

        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public CardType CardType { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}