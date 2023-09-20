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
                .NotEmpty().NotNull()
                .ChildRules(name =>
                {
                    name.RuleFor(p => p).Must(name =>
                    {
                        var hasNumber = false;
                        var hasUpper = false;
                        var hasLower = false;

                        foreach (var c in name)
                        {
                            if (char.IsDigit(c))
                                hasNumber = true;
                            else if (char.IsUpper(c))
                                hasUpper = true;
                            else if (char.IsLower(c))
                                hasLower = true;
                        }

                        return !hasNumber && hasUpper && hasLower;
                    }).WithMessage("O nome não pode conter números");
                })  
                .WithMessage("O nome é obrigatório")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 128 caracteres");

            RuleFor(p => p.Document)
                .NotEmpty().NotNull()
                .WithMessage("O documento é obrigatório")
                .Length(11, 18).WithMessage("O documento deve ter entre 11 e 18 caracteres");

            RuleFor(p => p.Password)
                .NotEmpty().NotNull().ChildRules(pass =>
                {
                    pass.RuleFor(p => p).Must(password =>
                    {
                        var hasNumber = false;
                        var hasUpper = false;
                        var hasLower = false;

                        foreach (var c in password)
                        {
                            if (char.IsDigit(c))
                                hasNumber = true;
                            else if (char.IsUpper(c))
                                hasUpper = true;
                            else if (char.IsLower(c))
                                hasLower = true;
                        }

                        return hasNumber && hasUpper && hasLower;
                    }).WithMessage("A senha deve conter pelo menos um número, uma letra maiúscula e uma letra minúscula");
                })  
                .Length(6, 20).WithMessage("A senha deve ter entre 6 e 20 caracteres");
        }
    }
}
