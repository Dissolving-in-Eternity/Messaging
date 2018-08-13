namespace Messaging.API.Models
{
    public class Recipient
    {
	    public string RecipientId { get; set; }

	    public string MessageId { get; set; }
	    public Message Message { get; set; }
    }
}
