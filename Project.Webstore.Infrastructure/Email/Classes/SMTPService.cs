using Project.Webstore.Infrastructure.Email.Interfaces;
using System.Net.Mail;

namespace Project.Webstore.Infrastructure.Email.Classes
{
    public class SMTPService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);

            SmtpClient client = new SmtpClient();

            client.Send(message);
        }
    }
}
