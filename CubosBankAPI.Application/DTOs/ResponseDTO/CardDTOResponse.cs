using CubosBankAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.ResponseDTO
{
    public class CardDTOResponse
    {
        public Guid Id { get; set; }
        public CardType CardType { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CardDTOResponse(Guid id, CardType cardtype, string number, string cvv, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            CardType = cardtype;
            Number = number;
            CVV = cvv;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
