using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Contacts.Commands
{
    public class CreateContactCommand :IRequest<int>
    {
       public CreateContactDTO ContactDTO { get; set; }

    }
}