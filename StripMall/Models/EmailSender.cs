using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace StripMall.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly Network network;

        public EmailSender(IOptions<Network> network)
        {
            this.network = network.Value ?? throw new Exception("Network credentials not found");
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(network.Email);
                message.Subject = subject;
                message.Body =  htmlMessage;

                using (var client = new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    Port = 587,
                    Credentials = new NetworkCredential(network.Email, network.Password)
                })
                {
                    await client.SendMailAsync(message);
                }
            }

        }
    }
}
