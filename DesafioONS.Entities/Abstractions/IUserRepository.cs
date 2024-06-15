using DesafioONS.Entities.Models;

namespace DesafioONS.Entities.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetUserByLoginAsync(string login);
        Task Create(User user);
        Task Update(User user);
        void Remove(User user);
    }
}