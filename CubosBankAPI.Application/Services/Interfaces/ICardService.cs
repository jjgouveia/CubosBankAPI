using CubosBankAPI.Application.DTOs.ResponseDTO;
using CubosBankAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardDTOResponse> CreateCard(Card card);
        Task<List<CardDTOResponse>> GetAllCardsByAccountId(Guid accountId);
    }
}
