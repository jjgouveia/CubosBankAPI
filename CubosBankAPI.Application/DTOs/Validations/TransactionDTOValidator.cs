using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.Validations
{
    public class TransactionDTOValidator : AbstractValidator<TransactionDTO>
    {
        public TransactionDTOValidator()
        {
            RuleFor(p => p.AccountId)
                .NotEmpty().NotNull()
                .WithMessage("O id da conta é obrigatório");

            RuleFor(p => p.Value)
                .NotEmpty().NotNull()
                .WithMessage("O valor da transação é obrigatório")
                .ChildRules(
                    value =>
                    {
                        value.RuleFor(p => p).Must(value =>
                        {
                            return value > 0;
                        }).WithMessage("O valor da transação deve ser maior que 0");
                    });
            RuleFor(p => p.Description)
                .NotEmpty().NotNull()
                .WithMessage("A descrição da transação é obrigatória")
                .Length(3, 128).WithMessage("A descrição da transação deve ter entre 3 e 128 caracteres");

        }
    }
}
