using DesafioONS.Business.DTOs;
using DesafioONS.Entities.Abstractions;
using MediatR;

namespace DesafioONS.Business.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {

            var users = await _unitOfWork.UserRepository.GetAll();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
                Contacts = user.Contacts.Select(contact => new ContactDTO
                {
                    Id = contact.Id,
                    PhoneNumber = contact.PhoneNumber                    

                }).ToList()
            }).ToList();
        }
    }
}