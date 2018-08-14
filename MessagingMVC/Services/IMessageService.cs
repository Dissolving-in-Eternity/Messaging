using System.Threading.Tasks;

namespace MessagingMVC.Services
{
	public interface IMessageService
	{
		Task<string> AddMessage(MessageDto message, string serviceUrl);
	}
}