using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PianoStoreProject.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmailSender(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// SMTP Code
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await ExecuteAsync(string.Empty, subject, message, email);
        }

        public async Task ExecuteAsync(string apiKey, string subject, string message, string email)
        {
            try
            {
                var pathToFile = _hostingEnvironment.WebRootPath
                             + Path.DirectorySeparatorChar.ToString()
                             + "EmailTemplate"
                             + Path.DirectorySeparatorChar.ToString()
                             + "Email.html";

                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }

                string messageBody = string.Format(builder.HtmlBody, message);
                var msg = new MailMessage()
                {
                    From = new MailAddress("info@hns.edu.pk", "FROST SOUNDS"),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = messageBody.ToString(),
                };
                msg.To.Add(email);

                var smtpClient = new SmtpClient("mail.hns.edu.pk", 587)
                {
                    Credentials = new NetworkCredential("info@hns.edu.pk", "cz4eH#02"),
                    EnableSsl = false,
                };
                await smtpClient.SendMailAsync(msg);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
