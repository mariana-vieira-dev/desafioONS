using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Users.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public UserDTO UserDTO { get; set; }
        
    }
}
