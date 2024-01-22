using Microsoft.AspNetCore.Identity.UI.Services;

namespace FoodDelivery.Web.Repository
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email,
           string subject, string htmlmessage)
        {
            return Task.CompletedTask;
        }
    }
}
