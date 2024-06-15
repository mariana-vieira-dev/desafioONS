using DesafioONS.Business.DTOs;

namespace DesafioONS.Business.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);

    }
}
