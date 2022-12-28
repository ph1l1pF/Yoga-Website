using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using YogaBackendAPI.Models;

namespace YogaBackendAPI.Services
{
    public class MessageSendService : IMessageSendService
    {
        private readonly IConfiguration _configuration;

        private static string _mailCompany;
        private static string _answerToCustomer;

        public MessageSendService(IConfiguration configuration)
        {
            _configuration = configuration;

            _mailCompany = _configuration.GetValue<string>("MailCompany");
            
            var signature = "Mit freundlichen Grüßen,\n\nDagmar Frerk\n\nYoga-Schule Heepen\n" +
                            $"Hillegosser Str.127\n33719 Bielefeld\nwww.yoga-schule-heepen.de\n{_mailCompany}\n0521-25258934";
            
            _answerToCustomer =
                "Vielen Dank für Ihre Anfrage. Ich beantworte Ihre Nachricht so schnell wie möglich."
                + $"\n Sie können mich auch jederzeit telefonisch erreichen.\n\n{signature}";
        }

        public void Send(RequestBody reqBody)
        {
            var mailCustomer = reqBody.MailCustomer.Trim();
            var nameCustomer = reqBody.NameCustomer.Trim();

            var mailToCompany = new MailMessage
            {
                From = new MailAddress(mailCustomer),
                Subject = "Yoga-Anfrage",
                Body = $"Neue Yoga-Anfrage von {nameCustomer}\n{mailCustomer}\n\n{reqBody.Message}"
            };
            mailToCompany.To.Add(_mailCompany);

            var mailToCustomer = new MailMessage
            {
                From = new MailAddress(_mailCompany),
                Subject = "Vielen Dank für Ihre Anfrage",
                Body = $"Hallo {nameCustomer},\n\n{_answerToCustomer}"
            };
            mailToCustomer.To.Add(mailCustomer);

            var smtpServer = new SmtpClient(_configuration.GetValue<string>("SmptServerMailCompany"))
            {
                Port = _configuration.GetValue<int>("SmptPortMailCompany"),
                Credentials = new NetworkCredential(_mailCompany, _configuration.GetValue<string>("PasswordMailCompany")),
                EnableSsl = true
            };
            smtpServer.Send(mailToCompany);
            smtpServer.Send(mailToCustomer);
        }
    }
}