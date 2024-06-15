using MediatR;

namespace DesafioONS.Business.Users.Commands
{
    public class RemoveUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
