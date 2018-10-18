using ProtectedBrowser.Common.Extensions;
using ProtectedBrowser.Common.Extensions;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Core.Mailer
{
    public class MailSender
    {
        /// <summary>
        /// Send Email To The Email Specified in To Email
        /// </summary>
        /// <param name="toMail"></param>
        /// <param name="subject"></param>
        /// <param name="messageBody"></param>
        /// <param name="CC"></param>
        /// <param name="BCC"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        ///     Thrown if <paramref cref="subject,messageBody"/> is null or empty string
        /// </exception>
        //public static async Task SendEmail(string toMail, string subject, string messageBody, string filepath = null, string CC = "", string BCC = "", List<AttachmentInMail> listOfAttachment = null, string fromName = "iCat")
        //{
        //    //#if (!DEBUG)

        //    ValidateEmailParams(toMail, subject, messageBody);
        //    SmtpClient objSmptClient = null;
        //    MailMessage objMailMessage;
        //    try
        //    {
        //        byte[] buffer;
        //        string fileName = "";


        //        objSmptClient = new SmtpClient(MailInfo.SMTPSERVER, MailInfo.SMTPSERVERPORT);
        //        objSmptClient.EnableSsl = MailInfo.SMTPISSSL;
        //        objSmptClient.Credentials = new System.Net.NetworkCredential(MailInfo.SMTPUSERNAME, MailInfo.SMTPPASSWORD);
        //        objMailMessage = new MailMessage(MailInfo.FROMEMAILADDRESS, toMail, subject, messageBody);
        //        if (!string.IsNullOrWhiteSpace(fromName))
        //            objMailMessage.From = new MailAddress(MailInfo.FROMEMAILADDRESS, fromName);

        //        if (listOfAttachment != null)
        //        {
        //            foreach (var item in listOfAttachment)
        //            {
        //                buffer = item.byteArray;
        //                fileName = item.name;

        //                System.Net.Mime.ContentType a = new System.Net.Mime.ContentType();
        //                a.Name = item.contenttype != "" ? item.contenttype : "";

        //                MemoryStream stream = new MemoryStream(item.byteArray);
        //                if (a.Name != "")
        //                {
        //                    Attachment objAttachment = null;
        //                    ContentDisposition objContentDisposition = null;
        //                    objAttachment = new Attachment(stream, fileName, a.Name);
        //                    objContentDisposition = objAttachment.ContentDisposition;
        //                    objMailMessage.Attachments.Add(objAttachment);

        //                }
        //                else
        //                {
        //                    objMailMessage.Attachments.Add(new Attachment(stream, fileName));
        //                }
        //            }
        //        }
        //        //if ToCC is not null and empty 
        //        if (CC.IsNotNullOrEmpty())
        //        {
        //            foreach (var address in CC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                objMailMessage.CC.Add(address);
        //            }

        //        }
        //        //if ToBCC is not null and empty 
        //        if (BCC.IsNotNullOrEmpty())
        //        {
        //            foreach (var address in BCC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                objMailMessage.Bcc.Add(address);
        //            }

        //        }

        //        //Specify that body is html type 
        //        objMailMessage.IsBodyHtml = true;

        //        if (!string.IsNullOrWhiteSpace(filepath))
        //        {

        //            Attachment objAttachment = null;
        //            ContentDisposition objContentDisposition = null;
        //            objAttachment = new Attachment(filepath, "text/calendar");
        //            objContentDisposition = objAttachment.ContentDisposition;
        //            objMailMessage.Attachments.Add(objAttachment);
        //        }
        //        try
        //        {
        //            objSmptClient.Send(objMailMessage);
        //        }
        //        catch (Exception ex)
        //        {
        //            //WriteException.WriteExceptionInFile(ex.ToString());
        //            //throw ex;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //WriteException.WriteExceptionInFile(ex.ToString());
        //        //return false;
        //    }

        //    //#else
        //    //return true;
        //    //#endif
        //}
        public static async Task SendEmail(string toMail, string subject, string messageBody, string filepath = null, string CC = "", string BCC = "", List<AttachmentInMail> listOfAttachment = null, string fromName = "ICat")
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

        /// <summary>
        /// Validate Email Parameters and Throws an exception
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="messageBody"></param>
        private static void ValidateEmailParams(string toEmail, string subject, string messageBody)
        {
            Ensure.Argument.NotNullOrEmpty(toEmail, "toEmail");
            Ensure.Argument.NotNullOrEmpty(subject, "subject");
            Ensure.Argument.NotNullOrEmpty(messageBody, "messageBody");
            if (!StringValidationExtensions.IsValidEmail(toEmail))
            {
                throw new ArgumentException("Email is not a valid email");
            }
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

    public class AttachmentInMail
    {
        public byte[] byteArray { get; set; }
        public string name { get; set; }
        public string contenttype { get; set; }
    }
}
