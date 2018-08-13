using MediatR;

namespace Notification.API.Events
{
	public class NotificationEvent : INotification 
	{
		public NotificationEvent(string recipientId)
		{
			RecipientId = recipientId;
		}
	 
		public string RecipientId { get; }
	}
}
