using Messaging.API.Models;

namespace Messaging.API.Repositories
{
	public interface IMessageRepository
	{
		string Add(Message message);
	}
}