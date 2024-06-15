using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Contacts.Queries
{
    public class GetContactByIdQuery : IRequest<ContactDTO>
    {
        public int Id { get; set; }
    }
}