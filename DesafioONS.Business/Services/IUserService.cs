using DesafioONS.Business.DTOs;

namespace DesafioONS.Business.Services
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string login, string password);

    }
}
