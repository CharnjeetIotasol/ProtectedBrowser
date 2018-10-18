using IotasmartBuild.EmailSender;
using IotasmartBuild.Framework.ViewModels.ContactUs;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.Configuration;
using ProtectedBrowser.Service.ContactUs;
using System.Web.Http;

namespace ProtectedBrowser.API
{
    [RoutePrefix("api")]
    public class ContactUsController : ApiController
    {
        private IContactUsService _contactUsService;
        private IEmailConfigurationService _emailConfiguration;
        public ContactUsController(IContactUsService contactUsService, IEmailConfigurationService emailConfigurationService)
        {
            _contactUsService = contactUsService;
            _emailConfiguration = emailConfigurationService;
        }

        /// <summary>
        ///  Api use for save contact request
        /// </summary>
        /// <returns></returns>
        [Route("contact-us")]
        [HttpPost]
        public IHttpActionResult ContactUsInsert(ContactUsViewModel model)
        {

            _contactUsService.ContactUsInsert(model.ToModel());
            try
            {
                var htmlData = GetContactHtml();
                string emailBody = string.Format(htmlData, model.Name, model.EmailAddress, model.PhoneNumber, model.Message);
                EmailSenders.SendEmail("malkitsingh.iotasol@gmail.com", "Contact Request", emailBody).Wait();
            }
            catch
            {
                return Json(new { message = "Some Error" });
            }
            return Json(new { message = "Save Successfully" });
        }

        public string GetContactHtml()
        {
            string html = "<html xmlns='http://www.w3.org/1999/xhtml'> <head> <title></title> </head> <body> <div> <div class='main-cont' style='border-style: solid; text-align: justify; max-width: 700px; font-family: Arial,Helvetica,sans-serif; margin: 0px auto; border-width: 1px; border-color: #2A3F54'> <div style='height:40px;background-color: 071a4f;'> <img src='http://www.iotasol.com/case-study/images/logo.png' style='height: 40px; background-color:#ffffff' /> </div> <div style='margin:30px;font-family:Arial,Helvetica,sans-serif;'> <div style='font-size:14px;'> <p><b>New contact request</b></p> <p style='font-size:11px;'> <table border='1' cellspacing='0' cellpadding='4' style='text-align:left;font-size:12px;'> <b>Name</b> : {0}<br> <b>Email</b> : {1}<br> <b>PhoneNo</b> : {2}<br> <b>Comment</b> : {3}</table> </p> </div> <div style='line-height: 25px;text-decoration: none;font-size: 11px;'>Sincerely,</div> <div style='line-height: 11px;text-decoration: none;font-size: 11px;'><b>IotaSmart Support Team</b></div> </div> </div> <table style='margin:0px auto;width:700px;font-size:11px;margin-top:10px'> <tbody> <tr> <td style='width:400px'> &#169; 2017 | <b> IotaSmart | </b> All rights reserved.<br></td> </tr> </tbody> </table> </div> </body> </html>";
            return html;
        }

        [Route("admin/contact-us")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        public IHttpActionResult ContactUsSelect([FromUri] SearchParam param)
        {
            var list = _contactUsService.ContactUsSelect(param.Id, param.Next, param.Offset);
            return Ok(list.SuccessResponse());
        }

        [Route("admin/contact-us/{id:long}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpDelete]
        public IHttpActionResult ContactUsDelete(long id)
        {
            _contactUsService.ContactUsDelete(id);
            return Ok("Contact request deleted successfully".SuccessResponse());
        }
    }
}
