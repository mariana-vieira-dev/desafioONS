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
            var user = await _unitOfWork.UserRepository.GetUserByLoginAsync(login);

            if (user == null || !VerifyPassword(user.Password, password))
                return null;

            return new UserDTO 
            { 
                Id = user.Id, 
                Name = user.Name, 
                Email = user.Email, 
                Login = user.Login, 
                Password = user.Password 
            };
        }

        private bool VerifyPassword(string hashedPassword, string password)
        {
            // Verificar a senha com o hash armazenado
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }    
}