using DesafioONS.Business.DTOs;
using DesafioONS.Entities.Abstractions;
using MediatR;

namespace DesafioONS.Business.Contacts.Queries
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllContactsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ContactDTO>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken)
        {
            var contacts = await _unitOfWork.ContactRepository.GetAll();
            return contacts.Select(contact => new ContactDTO 
            {
                Id = contact.Id,
                PhoneNumber = contact.PhoneNumber,
                UserId = contact.UserId           
            
            }).ToList();
        }
    }
}