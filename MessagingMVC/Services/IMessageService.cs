using System.Threading.Tasks;
using MessagingMVC.Dtos;

namespace MessagingMVC.Services
{
	public interface IMessageService
	{
		Task<string> AddMessage(MessageDto message, string serviceUrl);
	}
}