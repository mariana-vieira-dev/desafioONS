using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Contacts.Queries
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactDTO>>
    {
    }
}