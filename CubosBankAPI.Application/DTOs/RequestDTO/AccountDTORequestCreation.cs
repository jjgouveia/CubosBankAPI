using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.RequestDTO
{
    public class AccountDTORequestCreation
    {

        public string Branch { get; set; }
        public string Number { get; set; }
        

        public AccountDTORequestCreation(string branch, string number)
        {
            Branch = branch;
            Number = number;
        }
    }

    
}
