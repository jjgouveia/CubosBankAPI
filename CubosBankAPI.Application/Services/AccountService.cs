using CubosBankAPI.Application.DTOs;
using CubosBankAPI.Application.DTOs.ResponseDTO;
using CubosBankAPI.Application.DTOs.Validations;
using CubosBankAPI.Application.Services.Interfaces;
using CubosBankAPI.Domain.Entities;
using CubosBankAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.Services
{
    public class AccountService : IAccountService
     
    
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<AccountDTOResponse> CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new NullReferenceException("A requisição não pode ser nula ou vazia.");
            }

            AccountDTO accountDTO = new(account.Branch, account.Number, account.PersonId);

            var validator = new AccountDTOValidator().Validate(accountDTO);

            if (!validator.IsValid)
            {
                throw new Exception(string.Join(". ", validator.Errors.Select(x => x.ErrorMessage)));
            }

            bool accountExists = await _accountRepository.AccountExists(account.Number);

            if (accountExists)
            {
                throw new Exception("Conta já cadastrada. Revise as informações e tente novamente.");
            }

            Account accountCreated = await _accountRepository.CreateAsync(new(account.Branch, account.Number, account.PersonId));
            AccountDTOResponse accountCreatedDTO = new(accountCreated.Id, accountCreated.Branch, accountCreated.Number, accountCreated.CreatedAt, accountCreated.UpdatedAt);
            return accountCreatedDTO;
        }

        public Task<List<Account>> GetAllAccountsByPersonId(Guid personId)
        {  
            return _accountRepository.GetAllByPeopleId(personId);
            
        }
    }
}
