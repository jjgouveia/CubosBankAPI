using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubosBankAPI.Application.DTOs.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("O nome é obrigatório")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 128 caracteres");

            RuleFor(p => p.Document)
                .NotEmpty().NotNull().WithMessage("O documento é obrigatório")
                .Length(11, 18).WithMessage("O documento deve ter entre 11 e 18 caracteres");

            RuleFor(p => p.Password)
                .NotEmpty().NotNull().WithMessage("A senha é obrigatória")
                .Length(6, 20).WithMessage("A senha deve ter entre 6 e 20 caracteres");
        }
    }
}
