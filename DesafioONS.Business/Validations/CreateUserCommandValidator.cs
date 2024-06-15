using DesafioONS.Business.Users.Commands;
using FluentValidation;

namespace DesafioONS.Business.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.UserDTO.Name)
            .NotEmpty().WithMessage("Name is required.")            
            .Length(3,100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(u => u.UserDTO.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(u => u.UserDTO.Login)
                .NotEmpty().WithMessage("Login is required.")
                .Length(5,50).WithMessage("Login must be between 5 and 50 characters.");

            RuleFor(u => u.UserDTO.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(6,100).WithMessage("Password must be between 6 and 100 characters.");

            RuleFor(u => u.UserDTO.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Length(4,50).WithMessage("Role must be between 4 and 50 characters.");

            RuleForEach(u => u.UserDTO.Contacts)
                .SetValidator(new CreateContactCommandValidator());

        }
    }
}