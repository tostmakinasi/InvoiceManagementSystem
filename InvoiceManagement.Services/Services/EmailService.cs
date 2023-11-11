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
        public async Task SendAccountCompletionEmail(string link, string email, string userFullName, string username, string password)
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

            mailMessage.Subject = _baseSubject + "Kullanıcı Kayıt Bilgileriniz";
            mailMessage.Body = @$"
<h2 style=""color: #3498db; font-weight: bold;"">Kayıt Tamamlandı</h2>

    <p>Merhaba {userFullName},</p>

    <p>Kaydınız başarıyla tamamlandı. İşte hesap bilgileriniz:</p>

    <ul>
        <li><strong>Kullanıcı Adı:</strong> {username}</li>
        <li><strong>Şifre:</strong> {password}</li>
    </ul>

    <p>İyi günler dileriz!</p>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
