using DesafioONS.Entities.Abstractions;
using MediatR;

namespace DesafioONS.Business.Contacts.Commands
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(RemoveContactCommand command, CancellationToken cancellationToken)
        {

            var contact = await _unitOfWork.ContactRepository.GetById(command.Id);

            if (contact == null)
            {
                throw new InvalidOperationException("Contact not found");
            }

            _unitOfWork.ContactRepository.Remove(contact);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}