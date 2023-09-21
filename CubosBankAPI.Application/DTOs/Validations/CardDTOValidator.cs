using CubosBankAPI.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.Validations
{
    public class CardDTOValidator : AbstractValidator<CardDTO>
    {
        public CardDTOValidator()
        {

            RuleFor(p => p.Number)
                .NotEmpty().NotNull()
                .WithMessage("O número do cartão é obrigatório")
                .Length(16).WithMessage("O número do cartão deve ter 16 caracteres");

            RuleFor(p => p.CVV)
                .NotEmpty().NotNull()
                .WithMessage("O CVV é obrigatório")
                .ChildRules(cvv =>
                {
                    cvv.RuleFor(p => p).Must(cvv =>
                    {
                        var hasNumber = false;
                        var hasUpper = false;
                        var hasLower = false;

                        foreach (var c in cvv)
                        {
                            if (char.IsDigit(c))
                                hasNumber = true;
                            else if (char.IsUpper(c))
                                hasUpper = true;
                            else if (char.IsLower(c))
                                hasLower = true;
                        }

                        return hasNumber && !hasUpper && !hasLower;
                    }).WithMessage("O CVV deve conter apenas números");
                })
                .Length(3).WithMessage("O CVV deve ter 3 caracteres");

            RuleFor(p => p.CardType)
                .NotEmpty()
                .NotNull()
                .ChildRules(cardType =>
                {
                    cardType.RuleFor(p => p).Must(cardType =>
                    {
                        return string.Equals(cardType, "physical", StringComparison.OrdinalIgnoreCase)
                            || string.Equals(cardType, "virtual", StringComparison.OrdinalIgnoreCase);
                    }).WithMessage("CardType deve ser 'physical' ou 'virtual'");
                }).WithMessage("CardType é obrigatório"); 
        }
    }
}
