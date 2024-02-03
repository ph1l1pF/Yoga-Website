using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
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


            var confirmMsgToCustomer = new MimeMessage ();
            confirmMsgToCustomer.From.Add (new MailboxAddress ("Dagmar Frerk", _mailCompany));
            confirmMsgToCustomer.To.Add (new MailboxAddress (nameCustomer, mailCustomer));
            confirmMsgToCustomer.Subject = "Vielen Dank für Ihre Anfrage";

            confirmMsgToCustomer.Body = new TextPart ("plain") {
                Text = $"Hallo {nameCustomer},\n\n{_answerToCustomer}"};
            
            var messageToCompany = new MimeMessage ();
            messageToCompany.From.Add (new MailboxAddress (nameCustomer, _mailCompany));
            messageToCompany.To.Add (new MailboxAddress ("Dagmar Frerk", _mailCompany));
            messageToCompany.Subject = "Neue Yoga-Anfrage";

            messageToCompany.Body = new TextPart ("plain") {
                Text = @$"von: {mailCustomer}

                {reqBody.Message}
                "};

            using var client = new SmtpClient ();
            client.Connect (_configuration.GetValue<string>("SmptServerMailCompany"), _configuration.GetValue<int>("SmptPortMailCompany"), true);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate (_mailCompany, _configuration.GetValue<string>("PasswordMailCompany"));
            client.Send (confirmMsgToCustomer);
            client.Send (messageToCompany);
            client.Disconnect (true);
        }
    }
}