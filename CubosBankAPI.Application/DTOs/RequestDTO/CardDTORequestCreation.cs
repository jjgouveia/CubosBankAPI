using CubosBankAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.RequestDTO
{
    public class CardDTORequestCreation
    {
        public string CardType { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }

        public CardDTORequestCreation(string cardtype, string number, string cvv)
        {
            CardType = cardtype;
            Number = number;
            CVV = cvv;
        }
    }
}
