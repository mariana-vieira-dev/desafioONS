using DesafioONS.Entities.Abstractions;
using DesafioONS.Entities.Models;
using MediatR;

namespace DesafioONS.Business.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;        

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = command.UserDTO.Name,
                Email = command.UserDTO.Email,
                Login = command.UserDTO.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(command.UserDTO.Password),
                Role = command.UserDTO.Role,
                Contacts = command.UserDTO.Contacts.Select(c => new Contact
                {
                    PhoneNumber = c.PhoneNumber
                }).ToList()
            };

            await _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.CommitAsync();
            
            return user.Id;
        }
    }
}
