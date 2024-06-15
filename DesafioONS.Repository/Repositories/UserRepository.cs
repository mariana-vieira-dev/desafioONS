using DesafioONS.Entities.Abstractions;
using DesafioONS.Entities.Models;
using DesafioONS.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioONS.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var userList = await _context.Users.Include(u => u.Contacts).ToListAsync();
            return userList ?? Enumerable.Empty<User>();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.Include(u => u.Contacts).FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new InvalidOperationException("User not found");                
            }
            return user;
        }      

        public async Task Create(User user)
        {
            if(user is null)
            {
                throw new ArgumentNullException(nameof(user)); 
            }
            await _context.Users.AddAsync(user);           
        }

        public async Task Update(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            _context.Users.Update(user);
            await _context.SaveChangesAsync();           
        }

        public void Remove(User user)
        {
            if (user is null)
            {
                throw new InvalidOperationException("User not found");
            }

            _context.Users.Remove(user);                         
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Login == login);
        }
    }
}