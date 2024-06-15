using DesafioONS.Business.DTOs;
using MediatR;

namespace DesafioONS.Business.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}