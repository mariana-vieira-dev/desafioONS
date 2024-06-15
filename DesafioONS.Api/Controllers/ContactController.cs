using DesafioONS.Business.Contacts.Commands;
using DesafioONS.Business.Contacts.Queries;
using DesafioONS.Business.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioONS.Api.Controllers
{   
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery());
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery { Id = id });

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactDTO request)
        {
            var command = new CreateContactCommand { ContactDTO = request };
            await _mediator.Send(command);
            return Ok();
        }        

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var command = new UpdateContactCommand { ContactDTO = request };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveContactCommand { Id = id });
            return Ok();
        }
    }        
}