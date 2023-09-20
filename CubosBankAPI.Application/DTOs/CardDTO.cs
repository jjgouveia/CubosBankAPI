using CubosBankAPI.Domain;

namespace CubosBankAPI.Application.DTOs
{
    public class CardDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public CardType CardType { get; set; }
        public Guid AccountId { get; set; }
        public Guid PersonId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}