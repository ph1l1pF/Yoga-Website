using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using YogaBackendAPI.Models;

namespace YogaBackendAPI.Services
{
    public class MessageSendService : IMessageSendService
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;

        public MessageSendService(IConfiguration configuration, SmtpClient smtpClient)
        {
            _configuration = configuration;
            _smtpClient = smtpClient;
        }

        public void Send(RequestBody reqBody)
        {
            var mailCustomer = reqBody.MailCustomer.Trim();
            var nameCustomer = reqBody.NameCustomer.Trim();

            var mailToCompany = CreateMailToCompany(mailCustomer, nameCustomer, reqBody.Message);
            var mailToCustomer = CreateMailToCustomer(mailCustomer, nameCustomer);

            SendMail(mailToCompany);
            SendMail(mailToCustomer);
        }

        private MailMessage CreateMailToCompany(string mailCustomer, string nameCustomer, string message)
        {
            var mailToCompany = new MailMessage
            {
                From = new MailAddress(mailCustomer),
                Subject = "Yoga-Anfrage",
                Body = $"Neue Yoga-Anfrage von {nameCustomer}\n{mailCustomer}\n\n{message}"
            };
            mailToCompany.To.Add(_configuration.GetValue<string>("MailCompany"));
            return mailToCompany;
        }

        private MailMessage CreateMailToCustomer(string mailCustomer, string nameCustomer)
        {
            var signature = "Mit freundlichen Grüßen,\n\nDagmar Frerk\n\nYoga-Schule Heepen\n" +
                            $"Hillegosser Str.127\n33719 Bielefeld\nwww.yoga-schule-heepen.de\n{_configuration.GetValue<string>("MailCompany")}\n0521-25258934";
            var answerToCustomer =
                "Vielen Dank für Ihre Anfrage. Ich beantworte Ihre Nachricht so schnell wie möglich."
                + $"\n Sie können mich auch jederzeit telefonisch erreichen.\n\n{signature}";

            var mailToCustomer = new MailMessage
            {
                From = new MailAddress(_configuration.GetValue<string>("MailCompany")),
                Subject = "Vielen Dank für Ihre Anfrage",
                Body = $"Hallo {nameCustomer},\n\n{answerToCustomer}"
            };
            mailToCustomer.To.Add(mailCustomer);
            return mailToCustomer;
        }

        private void SendMail(MailMessage mail)
        {
            _smtpClient.Send(mail);
        }
    }
}
