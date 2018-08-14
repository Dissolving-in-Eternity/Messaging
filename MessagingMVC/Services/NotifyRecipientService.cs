using System.Net.Http;
using System.Threading.Tasks;

namespace MessagingMVC.Services
{
    public class NotifyRecipientService : INotifyRecipientService
    {
	    private readonly HttpClient _httpClient;

	    public NotifyRecipientService(HttpClient httpClient)
	    {
		    _httpClient = httpClient;
	    }

		public async Task<bool> Notify(string recipientId, string serviceUrl)
		{
			var uri = serviceUrl;
			var response = await _httpClient.PostAsync(uri + "/" + recipientId, null);

			return response.IsSuccessStatusCode;
		}
	}
}
