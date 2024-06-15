using DesafioONS.Entities.Models;
using MediatR;

namespace DesafioONS.Business.Contacts.Commands
{
    public class RemoveContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}