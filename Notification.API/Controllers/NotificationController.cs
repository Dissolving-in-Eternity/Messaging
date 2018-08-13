using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.API.Events;

namespace Notification.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Notification")]
    public class NotificationController : Controller
    {
	    private readonly IMediator _mediator;

	    public NotificationController(IMediator mediator)
	    {
		    _mediator = mediator;
	    }

	    // POST: api/Notification/5
		[HttpPost("{id}")]
		public IActionResult Notify([FromRoute] string id)
		{
			var result = _mediator.Publish(new NotificationEvent(id));

			if (result.IsCompletedSuccessfully)
				return Ok();

			return BadRequest();
		}
	}
}