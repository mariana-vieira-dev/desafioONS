using DesafioONS.Entities.Models;

namespace DesafioONS.Entities.Abstractions
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Create(Contact contact);
        Task Update(Contact contact);
        void Remove(Contact contact);
    }
}