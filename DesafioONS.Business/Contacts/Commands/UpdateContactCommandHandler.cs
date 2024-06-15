using DesafioONS.Entities.Abstractions;
using MediatR;

namespace DesafioONS.Business.Contacts.Commands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateContactCommand command, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.ContactRepository.GetById(command.ContactDTO.UserId);

            if (contact == null)
            {
                throw new InvalidOperationException("Contact not found");
            }

            contact.PhoneNumber = command.ContactDTO.PhoneNumber;          

            await _unitOfWork.CommitAsync();

        }
    }
}