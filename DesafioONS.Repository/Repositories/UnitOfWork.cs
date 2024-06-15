using DesafioONS.Entities.Abstractions;
using DesafioONS.Repository.Context;

namespace DesafioONS.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private IContactRepository? _contactRepository;        

        public UnitOfWork(AppDbContext context)
        {            
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ??
                    new UserRepository(_context);
            }
        }

        public IContactRepository ContactRepository 
        {
            get 
            {
                return _contactRepository = _contactRepository ??
                    new ContactRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}