using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace server.Services.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }

    public class SendGridMailService : IMailService
    {
        private readonly ISendGridClient _sendGridClient;
        public SendGridMailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            string fromEmail = "nardabrodovic99@gmail.com";
            string fromName = "narda";

            var msg = new SendGridMessage()
            {
                From =  new EmailAddress(fromEmail, fromName), 
                Subject = subject,
                PlainTextContent = content,

            };

             msg.AddTo(toEmail);

            await _sendGridClient.SendEmailAsync(msg);
        }
    }
}