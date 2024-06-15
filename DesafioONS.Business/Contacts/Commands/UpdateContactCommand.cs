using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Contacts.Commands
{
    public class UpdateContactCommand : IRequest
    {
        public ContactDTO ContactDTO { get; set; }
    }
}