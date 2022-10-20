using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Server.Api.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendGridClient _sendGridClient;
        public EmailController(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> SendEmailAsync(string toEmail, string subject, string content)
        {
            string fromEmail = "nardabrodovic99@gmail.com";
            string fromName = "narda";

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
                PlainTextContent = content,

            };

            msg.AddTo(toEmail);

            var response = await _sendGridClient.SendEmailAsync(msg);

            return Ok(response);
        }
    }
}
