using MediatR;
using Microsoft.Extensions.Logging;

namespace Notification.API.Events
{
	public class NotificationEventHandler : NotificationHandler<NotificationEvent>
	{
		private readonly ILogger<NotificationEventHandler> _logger;
	 
		public NotificationEventHandler(ILogger<NotificationEventHandler> logger)
		{
			_logger = logger;
		}

		protected override void Handle(NotificationEvent notification)
		{
			_logger.LogWarning($"Handled: { notification.RecipientId }");
		}
	}
}