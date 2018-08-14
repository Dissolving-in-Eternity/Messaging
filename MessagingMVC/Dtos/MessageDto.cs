using System.Collections.Generic;

namespace MessagingMVC.Dtos
{
	public class MessageDto
	{
		public string MessageId { get; set; }

		public string Subject { get; set; }

		public string Body { get; set; }

		public bool IsSent { get; set; }

		public IEnumerable<RecipientDto> Recipients { get; set; }
	}
}