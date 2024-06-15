using DesafioONS.Business.DTOs;
using DesafioONS.Entities.Abstractions;
using MediatR;

namespace DesafioONS.Business.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetById(query.Id);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }
            return new UserDTO
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
            };
        }
    }
}