using DesafioONS.Business.DTOs;
using DesafioONS.Entities.Abstractions;
using MediatR;

namespace DesafioONS.Business.Contacts.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetContactByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactDTO> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.ContactRepository.GetById(query.Id);
            if (contact == null)
            {
                throw new InvalidOperationException("Contact not found");
            }
            return new ContactDTO
            {
                Id = contact.Id,
                PhoneNumber = contact.PhoneNumber,
                UserId = contact.UserId
            };
        }
    }
}