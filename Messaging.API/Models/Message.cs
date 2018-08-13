using System.Collections.Generic;

namespace Messaging.API.Models
{
    public class Message
    {
	    public Message()
	    {
	    }

	    public string MessageId { get; set; }

	    public string Subject { get; set; }

	    public string Body { get; set; }

		// Is message has been delivered by notification service
	    public bool IsSent { get; set; }

	    public List<Recipient> Recipients { get; set; }
    }
}
