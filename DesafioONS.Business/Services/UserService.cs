using DesafioONS.Business.DTOs;
using DesafioONS.Entities.Abstractions;

namespace DesafioONS.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Authenticate(string login, string password)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserByLoginAsync(login);

                if (user == null || !VerifyPassword(user.Password, password))
                    return null;

                return new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Login = user.Login,
                    Role = user.Role,
                    Contacts = user.Contacts.Select(contact => new ContactDTO
                    {
                        Id = contact.Id,
                        PhoneNumber = contact.PhoneNumber
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                // Log exception (use your preferred logging framework)
                // For example: _logger.LogError(ex, "An error occurred while authenticating the user.");

                throw new ApplicationException("An error occurred while authenticating the user.", ex);
            }
        }

        private bool VerifyPassword(string hashedPassword, string password)
        {
            // Verificar a senha com o hash armazenado
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }

}