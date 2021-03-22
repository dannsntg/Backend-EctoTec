using Ecto_TecBE.Models;
using MimeKit;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Ecto_TecBE.Services
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderServiceController : ControllerBase, IEmailSenderService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSenderServiceController(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        // POST: Emailcontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        async Task IEmailSenderService.SendEmailAsync(string email, string nombre, string ciudad, string fecha)
        {
            MailRequest mail = new MailRequest();
            mail.Email = email;
            mail.Subject = "Test";
            mail.Body = "Estimado " + nombre + "Hemos recibido sus datos y nos pondremos en contacto con" +
                "usted en la brevedad posible. Enviaremos un correo con información a su cuenta: " + email +
                "<br>" +
                "Atte. Green Leaves" + ciudad + "a " + fecha;
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress("", mail.Email));
                message.Subject = mail.Subject;
                message.Body = new TextPart("html") { Text = mail.Body };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_smtpSettings.Server);
                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
