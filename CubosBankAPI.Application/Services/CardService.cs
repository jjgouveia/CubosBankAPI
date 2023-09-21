using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CubosBankAPI.Application.DTOs;
using CubosBankAPI.Application.DTOs.ResponseDTO;
using CubosBankAPI.Application.DTOs.Validations;
using CubosBankAPI.Application.Services.Interfaces;
using CubosBankAPI.Domain;
using CubosBankAPI.Domain.Entities;
using CubosBankAPI.Domain.Repositories;

namespace CubosBankAPI.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IAccountRepository _accountRepository;

        public CardService(ICardRepository cardRepository, IAccountRepository accountRepository)
        {
            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
        }

        public async Task<CardDTOResponse> CreateCard(Card card)
        {
            if (card == null)
            {
                throw new Exception("O cartão não pode ser nulo.");
            }

            var account = await _accountRepository.GetByIdAsync(card.AccountId);

            if (account == null)
            {
                throw new Exception("A conta associada ao cartão não foi encontrada.");
            }

            var cardDTO = new CardDTO(card.CardType, card.Number, card.CVV);
            var validator = new CardDTOValidator().Validate(cardDTO);

            //if (!validator.IsValid)
            //{
            //    throw new Exception(string.Join(". ", validator.Errors.Select(x => x.ErrorMessage)));
            //}

            if (card.CardType == CardType.Physical)
            {
                var physicalCards = await _cardRepository.GetPhysicalCardsByAccountIdAsync(card.AccountId);

                if (physicalCards)
                {
                    throw new Exception("A conta já possui um cartão físico.");
                }
            }   

            var createdCard = await _cardRepository.CreateAsync(card);

            return new CardDTOResponse(createdCard.Id, createdCard.CardType, createdCard.Number, createdCard.CVV, createdCard.CreatedAt, createdCard.UpdatedAt);
        }

        //public async Task<List<CardDTOResponse>> GetAllCardsByAccountId(Guid accountId)
        //{
        //    // Obtenha a lista de cartões associados à conta com base no accountId
        //    var cards = await _cardRepository.GetCardsByAccountIdAsync(accountId);

        //    // Mapeie os cartões para DTOs de resposta
        //    var cardDTOs = cards.Select(card => new CardDTOResponse(card.Id, card.CardType, card.Number, card.CVV, card.CreatedAt, card.UpdatedAt)).ToList();

        //    return cardDTOs;
        //}
    }
}
