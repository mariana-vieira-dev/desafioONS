using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Users.Commands
{
    public class CreateUserCommand() : IRequest<int>
    {
        public CreateUserDTO UserDTO { get; set; }            

    }
}
