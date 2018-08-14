using System.ComponentModel.DataAnnotations;

namespace MessagingMVC.Models
{
	public class MessageViewModel
	{
		[Display(Name = "Message service url")]
		public string MessageServiceUrl { get; set; }

		[Display(Name = "Notification service url")]
		public string NotificationServiceUrl { get; set; }

		public string Subject { get; set; }

		public string Body { get; set; }

		[Required]
		[Display(Name = "Recipient ids")]
		public string RecipientIds { get; set; }

		public string MessageId { get; set; }
	}
}