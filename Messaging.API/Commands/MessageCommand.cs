using System.Collections.Generic;
using System.Runtime.Serialization;
using MediatR;
using Messaging.API.Models;

namespace Messaging.API.Commands
{
	[DataContract]
    public class MessageCommand : IRequest<string>
    {
	    [DataMember]
	    public string MessageId { get; private set; }

	    [DataMember]
	    public string Subject { get; private set; }

	    [DataMember]
	    public string Body { get; private set; }

	    [DataMember]
	    public bool IsSent { get; private set; }

	    [DataMember]
	    public List<RecipientDto> Recipients { get; private set; }

	    public MessageCommand(string messageId, string subject, string body, bool isSent, List<RecipientDto> recipients)
	    {
		    MessageId = messageId;
		    Subject = subject;
		    Body = body;
		    IsSent = isSent;
		    Recipients = recipients;
	    }
    }

	public class RecipientDto
	{
		public string RecipientId { get; set; }

		public string MessageId { get; set; }
	}

	public static class RecipientExt
	{
		public static Recipient ToModel(this RecipientDto dto)
		{
			return new Recipient
			{
				//MessageId = dto.MessageId,
				RecipientId = dto.RecipientId
			};
		}
	}
}
