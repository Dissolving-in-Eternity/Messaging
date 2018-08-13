using System.Collections.Generic;
using System.Linq;
using MediatR;
using Messaging.API.Commands;
using Messaging.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Messaging.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        private readonly MessageContext _context;
	    private readonly IMediator _mediator;

        public MessagesController(MessageContext context, IMediator mediator)
        {
	        _context = context;
	        _mediator = mediator;
        }

		// TODO: Added for testing purposes. Don't forget to remove.
        // GET: api/Messages
        [HttpGet]
        public IEnumerable<Message> GetMessages()
        {
			var messages = _context.Messages
				.Include(m => m.Recipients)
				.ToList();

			return messages;
        }

        // POST: api/Messages
        [HttpPost]
        public IActionResult PostMessage([FromBody]MessageCommand command)
        {
			var commandResult = _mediator.Send(command);

			if (commandResult.IsCompletedSuccessfully)
				return (IActionResult)Ok(commandResult.Result);

			return (IActionResult)BadRequest();
		}
    }
}