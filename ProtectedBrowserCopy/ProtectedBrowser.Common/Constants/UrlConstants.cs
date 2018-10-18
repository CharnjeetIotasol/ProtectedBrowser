using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Common.Constants
{
   public class UrlConstants
    {
        public const string baseUrl = "http://localhost:49617";
        //public const string baseUrl = "http://icatapp.azurewebsites.net";
    }
    public class EmailTemplate {
        public const string template = "<head><title></title></head><body><div><div class='main-cont' style='border-style: solid; text-align: justify; max-width: 700px; font-family: Arial,Helvetica,sans-serif; margin: 0px auto; border-width: 2px; border-color: #2A3F54'><div style = 'margin:30px;font-family:Arial,Helvetica,sans-serif;'><div style='font-size:13px;'><p><b>Hi {0},</b></p><p>We have received a request to reset your password for Iotasmart account.</p><p>Simply click  on the below button to set a new password</p><h4 style = 'margin-top:20px'><a href='{1}' style='padding: 8px;background-color: rgba(0, 78, 255, 0.65);width: 211px;margin-left: auto;color: white;border-radius: 4px;margin-right: auto;text-decoration:none'>Set a new password</a></h4><p> If you haven''t asked to change your password, don''t worry.You password is still safe and you can delete this mail.</p></div><div style = 'line-height: 25px;text-decoration: none;font-size: 11px;' > Sincerely,</div><div style = 'line-height: 11px;text-decoration: none;font-size: 11px;'><b> Iotasmart Support Team</b></div><br><img src = 'http://icatapp.azurewebsites.net/wwwroot/images/logo.jpg' style= 'height: 40px; width:140px;'/></div></div><table style= 'margin:0px auto;width:700px;font-size:11px;margin-top:10px'><tbody><tr><td style= 'width:400px' > &#169; 2017 | <b>  Iotasol Smart | </b> All rights reserved.<br></td></tr></tbody></table></div></body></html > '";
    }
}
