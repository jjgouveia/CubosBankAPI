using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.ResponseDTO
{
    public class AccountDTOResponse
    {
        public Guid Id { get; set; }
        public string Branch { get; set; }
        public string Number { get; set; }
 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AccountDTOResponse(Guid id, string branch, string accountNumber, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Branch = branch;
            Number = accountNumber;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
