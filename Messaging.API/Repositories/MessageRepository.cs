using Messaging.API.Models;

namespace Messaging.API.Repositories
{
	public class MessageRepository : IMessageRepository
	{
		private readonly MessageContext _context;

		public MessageRepository(MessageContext context)
		{
			_context = context;
		}

		public string Add(Message message)
		{
			var addedMessage = _context.Messages.Add(message);
			_context.SaveChanges();

			return addedMessage.Entity.MessageId;
		}
	}
}