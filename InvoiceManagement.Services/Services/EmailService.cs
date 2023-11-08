using InvoiceManagement.Core.OptionsModels;
using InvoiceManagement.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly string _baseSubject = "Local Host | InvoiceManagement | ";
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        public async Task SendAccountCompletionEmail(string link, string email)
        {
            var smtpClient = new SmtpClient();

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = _emailSettings.Host;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(email);

            mailMessage.Subject = _baseSubject + "Kullanıcı aktivasyon linki";
            mailMessage.Body = @$"<h4>Kullanıcı kaydınızı tamamlamak için aşağıdaki linke tıklayınız.</h4>
                                 <p><a href ='{link}'> Kullanıcı aktivasyon link </a></p>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
