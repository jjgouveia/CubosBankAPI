using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.Validations
{
    public class AccountDTOValidator : AbstractValidator<AccountDTO>
    {
        public AccountDTOValidator()
        {
            RuleFor(p => p.PersonId)
                .NotEmpty().NotNull()
                .WithMessage("O id da pessoa é obrigatório");

            RuleFor(p => p.Number)
                .NotEmpty().NotNull()
                .WithMessage("O número da conta é obrigatório")
                .Length(9).WithMessage("O número da conta deve ter 6 caracteres");

            RuleFor(p => p.Branch)
                .NotEmpty().NotNull()
                .ChildRules(branch =>
                {
                    branch.RuleFor(p => p).Must(branch =>
                    {
                        var hasNumber = false;
                        var hasUpper = false;
                        var hasLower = false;

                        foreach (var c in branch)
                        {
                            if (char.IsDigit(c))
                                hasNumber = true;
                            else if (char.IsUpper(c))
                                hasUpper = true;
                            else if (char.IsLower(c))
                                hasLower = true;
                        }

                        return hasNumber && !hasUpper && !hasLower;
                    }).WithMessage("A agência deve conter apenas números");
                })
                .WithMessage("A agência é obrigatória")
                .Length(3).WithMessage("A agência deve ter 3 caracteres");

            
        }
    }
}
