using DesafioONS.Entities.Abstractions;
using DesafioONS.Entities.Models;
using DesafioONS.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioONS.Repository.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var contactList = await _context.Contacts.Include(c => c.User).ToListAsync();
            return contactList ?? Enumerable.Empty<Contact>();
        }

        public async Task<Contact> GetById(int id)
        {
            var contact = await _context.Contacts.Include(c => c.User).FirstOrDefaultAsync();

            if(contact is null)
            {
                throw new InvalidOperationException("Contact not found");
            }
            return contact;
        }        

        public  async Task Create(Contact contact)
        {
            if(contact is null)
            {
                throw new ArgumentNullException(nameof(contact)); 
            }

            await _context.Contacts.AddAsync(contact);
        }

        public async Task Update(Contact contact)
        {
           if(contact is null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();            
        }

        public void Remove(Contact contact)
        {     
            if(contact is null)
            {
                throw new InvalidOperationException("Contact not found");
            }

            _context.Contacts.Remove(contact);           
        }        
    }
}