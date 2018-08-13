using System;
using System.Linq;
using System.Runtime.Serialization;
using MediatR;
using Messaging.API.Models;
using Messaging.API.Repositories;

namespace Messaging.API.Commands
{
	[DataContract]
    public class MessageCommandHandler
	//That is the code that correlates commands with command handlers. The handler is just a simple class, but it inherits from
	//RequestHandler<T>, and MediatR makes sure it is invoked with the correct payload.
        : RequestHandler<MessageCommand, string>
    {
        private readonly IMessageRepository _messageRepository;

        // Using DI to inject infrastructure persistence Repositories
        public MessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

	    protected override string Handle(MessageCommand command)
        {
	        var message = new Message
	        {
		        MessageId = command.MessageId,
		        Subject = command.Subject,
		        Body = command.Body,
		        IsSent = command.IsSent,
				Recipients = command.Recipients
					.Select(r => r.ToModel())
					.ToList()
	        };

             var id = _messageRepository.Add(message);

            return id;
        }

	    
    }
}
