using System.Threading.Tasks;

namespace MessagingMVC.Services
{
	public interface INotifyRecipientService
	{
		Task<bool> Notify(string recipientId, string serviceUrl);
	}
}