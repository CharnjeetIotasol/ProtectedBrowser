using System;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using System.Configuration;

namespace IotasmartBuild.EmailSender
{
    public class EmailSenders
    {
        public static async Task SendEmail(string toMail, string subject, string messageBody, string filepath = null, string CC = "", string BCC = "" ,string fromName = "Vanworld")
        {
            String apiKey = MailInfo.SENDGRIDAPIKEY;
            dynamic sg = new SendGrid.SendGridAPIClient(apiKey, "https://api.sendgrid.com");

            Email from = new Email(MailInfo.FROMEMAILADDRESS);
            Email to = new Email(toMail);
            Content content = new Content("text/html", messageBody);
            Mail mail = new Mail(from, subject, to, content);
            // Email email = new Email("nitin.iotasol@gmail.com", fromName);
            // mail.Personalization[0].AddTo(email);
            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
    internal class MailInfo
    {
        public readonly static string FROMEMAILADDRESS = ConfigurationManager.AppSettings["FROMEMAILADDRESS"];
        public readonly static string SMTPUSERNAME = ConfigurationManager.AppSettings["SMTPUSERNAME"];
        public readonly static string SMTPPASSWORD = ConfigurationManager.AppSettings["SMTPPASSWORD"];
        public readonly static string SMTPSERVER = ConfigurationManager.AppSettings["SMTPSERVER"];
        public readonly static bool SMTPISSSL = Boolean.Parse(ConfigurationManager.AppSettings["SMTPISSSL"]);
        public readonly static int SMTPSERVERPORT = int.Parse(ConfigurationManager.AppSettings["SMTPSERVERPORT"]);
        public readonly static string SENDGRIDAPIKEY = ConfigurationManager.AppSettings["SENDGRIDAPIKEY"];

    }
}
