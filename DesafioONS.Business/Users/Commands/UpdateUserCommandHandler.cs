using DesafioONS.Entities.Abstractions;
using DesafioONS.Entities.Models;
using MediatR;

namespace DesafioONS.Business.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetById(command.UserDTO.Id);

            if (user == null) 
            {
                throw new InvalidOperationException("User not found");
            }

            //Atualiza as propriedades do usuário
            user.Name = command.UserDTO.Name;
            user.Email = command.UserDTO.Email;
            user.Login = command.UserDTO.Login;
            user.Password = command.UserDTO.Password;
            user.Role = command.UserDTO.Role;

            // Atualiza os contatos
            var existingContacts = user.Contacts.ToList();
            var newContacts = command.UserDTO.Contacts.Select(c => new Contact
            {
                Id = c.Id,
                PhoneNumber = c.PhoneNumber,
                UserId = user.Id
            }).ToList();

            foreach (var contact in newContacts)
            {
                var existingContact = existingContacts.FirstOrDefault(c => c.Id == contact.Id);
                if (existingContact != null)
                {
                    existingContact.PhoneNumber = contact.PhoneNumber;
                }
                else
                {
                    user.Contacts.Add(contact);
                }
            }

            // Remove contatos que não estão na nova lista
            foreach (var contact in existingContacts)
            {
                if (!newContacts.Any(c => c.Id == contact.Id))
                {
                   _unitOfWork.ContactRepository.Remove(contact);
                }
            }

            await _unitOfWork.CommitAsync();
        }
    }
}