using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}