using System;
using System.Linq;
using System.Threading.Tasks;
using MessagingMVC.Dtos;
using Microsoft.AspNetCore.Mvc;
using MessagingMVC.Models;
using MessagingMVC.Services;

namespace MessagingMVC.Controllers
{
    public class MessagesController : Controller
    {
	    private readonly IMessageService _messageService;
	    private readonly INotifyRecipientService _notifyRecipientService;

        public MessagesController(IMessageService messageService, INotifyRecipientService notifyRecipientService)
        {
	        _messageService = messageService;
	        _notifyRecipientService = notifyRecipientService;
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
	        var model = new MessageViewModel
	        {
		        MessageServiceUrl = "http://localhost:62427/api/messages",
		        NotificationServiceUrl = "http://localhost:53792/api/notification"
	        };

            return View(model);
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
	            var ids = model.RecipientIds
		            .Split(new[] { ' ', ',', ';', '\n', '\r', '.' }, StringSplitOptions.RemoveEmptyEntries);

	            var mesage = new MessageDto
	            {
		            Subject = model.Subject,
		            Body = model.Body,
		            Recipients = ids.Select(id => new RecipientDto { RecipientId =  id }).ToList()
	            };

	            var result = await _messageService.AddMessage(mesage, model.MessageServiceUrl);
	            model.MessageId = result;

	            if (ids != null && ids.Length > 0)
	            {
					// TODO: notify all
		            var res = await _notifyRecipientService.Notify(ids.First(), model.NotificationServiceUrl);
	            }

	            return View(model);
            }

            return View();
        }
    }
}
