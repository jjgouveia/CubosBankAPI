using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Number { get; set; }
        public string Branch { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
