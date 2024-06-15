﻿using DesafioONS.Business.DTOs;
using DesafioONS.Business.Users.Commands;
using DesafioONS.Business.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioONS.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]     
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO request)
        {
            var command = new CreateUserCommand { UserDTO = request };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var command = new UpdateUserCommand { UserDTO = request };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _mediator.Send(new RemoveUserCommand { Id = id });
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid operation when trying to remove user with ID {UserId}", id);
                return NotFound(new { Message = ex.Message }); // Retorna 404 Not Found se o usuário não for encontrado
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while removing user with ID {UserId}", id);
                return StatusCode(500, new { Message = "An error occurred while processing your request" }); // Retorna 500 Internal Server Error para outras exceções
            }

        }        
    }
}