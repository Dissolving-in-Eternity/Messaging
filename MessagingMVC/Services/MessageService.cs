using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MessagingMVC.Services
{
    public class MessageService : IMessageService
    {
	    private readonly HttpClient _httpClient;

	    public MessageService(HttpClient httpClient)
	    {
		    _httpClient = httpClient;
	    }

	    public async Task<string> AddMessage(MessageDto message, string serviceUrl)
	    {
		    var uri = serviceUrl;
		    var content = new StringContent(JsonConvert.SerializeObject(message), System.Text.Encoding.UTF8, "application/json");

		    var response = await _httpClient.PostAsync(uri, content);
		    response.EnsureSuccessStatusCode();

		    var messageId = await response.Content.ReadAsStringAsync();

		    return messageId;
	    }
    }
}
