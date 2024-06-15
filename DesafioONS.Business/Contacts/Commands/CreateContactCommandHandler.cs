using DesafioONS.Entities.Abstractions;
using DesafioONS.Entities.Models;
using DesafioONS.Repository.Context;
using MediatR;

namespace DesafioONS.Business.Contacts.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateContactCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;          
        }

        public async Task<int> Handle(CreateContactCommand command, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                PhoneNumber = command.ContactDTO.PhoneNumber                
            };

            await _unitOfWork.ContactRepository.Create(contact);
            await _unitOfWork.CommitAsync();

            return contact.Id;
        }
    }
}