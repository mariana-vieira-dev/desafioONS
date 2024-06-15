using DesafioONS.Entities.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DesafioONS.Business.Users.Commands
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveUserCommandHandler> _logger;

        public RemoveUserCommandHandler(IUnitOfWork unitOfWork, ILogger<RemoveUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(RemoveUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Obtendo o usuário a ser removido
                var user = await _unitOfWork.UserRepository.GetById(command.Id);
                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found", command.Id);
                    throw new InvalidOperationException("User not found");
                }

                
                _unitOfWork.UserRepository.Remove(user);                
                await _unitOfWork.CommitAsync();

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while removing user with ID {UserId}", command.Id);
                throw;
            }
        }
    }
}