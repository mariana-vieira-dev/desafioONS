using DesafioONS.Business.DTOs;
using FluentValidation;

namespace DesafioONS.Business.Validations
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactDTO>
    {
        public CreateContactCommandValidator() 
        {
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Length(11).WithMessage("Phone Number must be just numbers and exactly 11 characters long.");
        }       
    }
}