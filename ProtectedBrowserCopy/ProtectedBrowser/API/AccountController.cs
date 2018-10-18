using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using ProtectedBrowser.Models;
using ProtectedBrowser.Framework.ViewModels.User;
using System.Threading.Tasks;
using ProtectedBrowser.Framework.CustomFilters;
using ProtectedBrowser.Framework.GenericResponse;
using Microsoft.AspNet.Identity;
using ProtectedBrowser.Service.Users;
using ProtectedBrowser.GenericResponse;
using ProtectedBrowser.Common.Constants;
using ProtectedBrowser.Core.Mailer;
using ProtectedBrowser.Common.Success;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.Configuration;
using ProtectedBrowser.Common.Enums;
using ProtectedBrowser.Common.Extensions;

namespace ProtectedBrowser.API
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IUserService _userService;
        private IEmailConfigurationService _emailConfiguration;
        public AccountController(IUserService userService, IEmailConfigurationService emailConfiguration)
        {
            _userService = userService;
            _emailConfiguration = emailConfiguration;
        }
        ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult RegisterUser([FromBody] UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(ModelState.ErrorResponse());
                }
                if (UserManager.Users.Any(x => x.Email.Equals(model.Email) && !x.IsDeleted))
                {
                    return Ok(string.Format(ErrorMessage.AccountError.EMAIL_ALREADY_REGISTERED, model.Email).ErrorResponse());
                }
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.MobileNo,
                    PhoneNumberConfirmed = false,
                    EmailConfirmed = false,
                    IsActive = true,
                    TwoFactorEnabled = model.RoleName == "" ? true : false,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                IdentityResult result = UserManager.Create(user);
                if (!result.Succeeded)
                {
                    if (result == null)
                    {
                        return Ok(InternalServerError().ErrorResponse());
                    }
                    if (result.Errors != null)
                    {
                        foreach (string error in result.Errors)
                        {
                            return Ok(error.ErrorResponse());
                        }
                    }
                }
                UserManager.AddToRole(user.Id, model.RoleName);

                SendEmailForEmailConfirm(user.Id, user.Email, model.FirstName + " " + model.LastName, user.UniqueCode);
                return Ok(SuccessMessage.AccountSuccess.USER_REGISTERED.SuccessResponse());

            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }
        /// <summary>
        /// Method for send email for email varification and password reset.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toEmail"></param>
        /// <param name="fullName"></param>
        /// <param name="uniqueCode"></param>
        public void SendEmailForEmailConfirm(long userId, string toEmail, string fullName, string uniqueCode)
        {
            var configData = _emailConfiguration.EmailConfigurationSelect(EmailConfigurationKey.EmailVerification.ToString());

            string code = UserManager.GenerateEmailConfirmationToken(userId);
            code = HttpUtility.UrlEncode(code);
            var callbackUrl = UrlConstants.baseUrl + "/reset-password?p=" + uniqueCode + "&code=" + code;
            var emailBody = string.Format(configData.ConfigurationValue, fullName, callbackUrl);
            MailSender.SendEmail(toEmail, EmailConstants.CONFIRM_YOUR_ACCOUNT, emailBody).Wait();
        }

        #region Login
        /// <summary>
        /// api use to login the app
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login(UserViewModel model)
        {
            var userFound = UserManager.Find(model.Email, model.Password);
            if (userFound == null)
            {
                return Ok(ErrorMessage.AccountError.INCORRECT.ErrorResponse());
            }
            if (userFound.IsDeleted)
            {
                return Ok(ErrorMessage.AccountError.DELETED.ErrorResponse());
            }
            return await GetLoginJson(userFound);
        }
       
        /// <summary>
        /// get login user detail 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetLoginJson(ApplicationUser user)
        {
            var token = await CreateToken(user.Email);
            if (string.IsNullOrEmpty(token.Error)) //if error is not found return token 
            {
                if (user != null)
                {
                    token.TokenData = new tokenData
                    {
                        Token = new tokenObj
                        {
                            Expires = DateTimeOffset.Now.AddDays(14),
                            AccessToken = token.AccessToken,
                            TokenType = token.TokenType
                        },
                        User = new UserViewModel
                        {
                            Id=user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            UserName = user.Email,
                            FullName = user.FirstName+" "+ user.LastName,
                            Roles = UserManager.GetRoles(user.Id).ToList(),
                            ProfileImageUrl = user.ProfilePic,
                            UniqueCode = user.UniqueCode,
                            IsActive=user.IsActive,
                            IsDeleted=user.IsDeleted,
                            EmailConfirmed=user.EmailConfirmed
                        },
                    };

                }
                return Ok(token.TokenData.SuccessResponse());
            }
            return Ok(token.ErrorDescription.ErrorResponse());
        }

        #endregion

        #region Forgot-Password
        /// <summary>
        /// send mail for forget password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("forgot/password")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult ForgotPassword(UserViewModel model)
        {
            try
            {
                string host = HttpContext.Current.Request.Url.Host;
                var user = GetUser(model.UserName);
                if (user == null) return Ok(ErrorMessage.AccountError.INVALID_EMAIL.ErrorResponse());

                string code = UserManager.GeneratePasswordResetToken(user.Id);
                code = HttpUtility.UrlEncode(code);

                var callbackUrl = "http://" + host + "/account/recover/" + user.UniqueCode + "?code=" + code;
                // var userData = _userService.SelectUserByUniqueCode(user.UniqueCode);
                var configData = _emailConfiguration.EmailConfigurationSelect(EmailConfigurationKey.ForgotPassword.ToString());
                //var configData = _emailConfiguration.GetEmailConfiguration(EmailConfigurationKey.ForgotPassword.ToString());

                var emailBody = string.Format(configData.ConfigurationValue, user.FirstName, callbackUrl);
                MailSender.SendEmail(user.Email, EmailConstants.FORGOT_PASSWORD, emailBody).Wait();
                return Ok(SuccessMessage.AccountSuccess.FORGOT_PASSWORD_LINK.SuccessResponse());

            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }
        /// <summary>
        /// api use for reset the password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("reset/password")]
        public IHttpActionResult ResetPassword(UserViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.UniqueCode))
                {
                    return Ok(ErrorMessage.AccountError.INVALID.ErrorResponse());
                }
                var user = _userService.SelectUserByUniqueCode(model.UniqueCode);
                if (user == null)
                    return Ok(ErrorMessage.AccountError.INVALID_LINK.ErrorResponse());
                IdentityResult result = UserManager.ResetPassword(Convert.ToInt64(user.Id), HttpUtility.UrlDecode(model.Code), model.Password);
                if (result.Succeeded)
                {
                    return Ok(SuccessMessage.AccountSuccess.PASSWORD_CHANGED.SuccessResponse());
                }
                else
                {
                    return Ok(result.Errors.FirstOrDefault().ErrorResponse());
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }

        /// <summary>
        /// Email confirmation and password reset api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("confirm/email")]
        public async Task<IHttpActionResult> ConfirmEmail(UserViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.UniqueCode))
                {
                    return Ok(ErrorMessage.AccountError.INVALID.ErrorResponse());
                }
                var user = _userService.SelectUserByUniqueCode(model.UniqueCode);
                if (user == null)
                    return Ok(ErrorMessage.AccountError.INVALID_LINK.ErrorResponse());
                IdentityResult result = await this.UserManager.ConfirmEmailAsync(Convert.ToInt64(user.Id), HttpUtility.UrlDecode(model.Code));
                if (result.Succeeded)
                {
                    var appUser = UserManager.FindByEmail(user.Email);
                    appUser.PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);
                    appUser.IsActive = true;
                    await UserManager.UpdateAsync(appUser);
                    //string code = UserManager.GenerateEmailConfirmationToken(user.Id);
                    return Ok(SuccessMessage.AccountSuccess.PASSWORD_CHANGED.SuccessResponse());
                }
                else
                {
                    return Ok(ErrorMessage.AccountError.INVALID_LINK.ErrorResponse());
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }

        /// <summary>
        /// Change password api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("changePassword")]
        [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> ChangePassword(UserViewModel model)
        {
            try
            {
                var user = UserManager.FindById(User.Identity.GetUserId<long>());
              
                var userFound = UserManager.Find(user.UserName, model.OldPassword);
                if(userFound == null)
                {
                    return Ok("Old password does not match".ErrorResponse());
                }
                //var user = UserManager.FindById(User.Identity.GetUserId<long>());
                if (user != null)
                {
                    user.IsActive = true;
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);
                    await UserManager.UpdateAsync(user);
                    return Ok("Password has been changed successfully".SuccessResponse());
                }
                return Ok("Invalid user please login.".ErrorResponse());
            }
            catch (Exception ex)
            {
             
                return Ok(ex.Message.ErrorResponse());
            }
        }
        /// <summary>
        /// User details api
        /// </summary>
        /// <returns></returns>
        [Route("user")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUserDetail()
        {
            var userId = User.Identity.GetUserId<long>();
            var userProfile = UserManager.FindById(userId);
            if (userProfile != null)
            {

                var User = new UserViewModel
                {
                    FirstName = userProfile.FirstName,
                    Roles = UserManager.GetRoles(userId).ToList(),
                    LastName = userProfile.LastName,
                    UserName = userProfile.Email,
                    FullName = userProfile.FirstName+" "+ userProfile.LastName,
                    Id = userId,
                    ProfileImageUrl = userProfile.ProfilePic,
                    UniqueCode = userProfile.UniqueCode,
                    PhoneNumber = userProfile.PhoneNumber
                  
                };
                return Ok(User.SuccessResponse());
            }
            return Ok("Could Not Fetch Profile".ErrorResponse());
        }

        /// <summary>
        /// Update user details api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("user")]
        [Authorize]
        [HttpPut]
        public IHttpActionResult UpdateUserDetail(UserViewModel model)
        {
            try
            {
                if (model == null)
                    return Ok("Invalid data".ErrorResponse());
                var user = UserManager.FindById(Convert.ToInt64(model.Id));
                var userEmailCheck = UserManager.FindByEmail(user.Email);
                if (userEmailCheck != null && userEmailCheck.Id != user.Id && !user.IsDeleted)
                {
                    return Ok(string.Format("{0} Email already registered with another account.", user.Email).ErrorResponse());
                }
                UserManager.Update(user);
                return Ok("User details updated successfully.".SuccessResponse());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }

        #endregion

        #region Helper methods
        /// <summary>
        /// Create Token object for user
        /// </summary>
        /// <param name="user">Login model for User</param>
        /// <returns>Token View Model</returns>
        async Task<TokenViewModel> CreateToken(string email)
        {
            IEnumerable<KeyValuePair<string, string>> postData = new Dictionary<string, string>
            {
                {"username",email},
                {"password","temp"},
                {"grant_type","password"}
            };
            var WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", WWW_FORM_URLENCODED);

                    content.Headers.Add("user-found", "true");
                    HttpResponseMessage response = await httpClient.PostAsync(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/api/token", content);

                    var respo = await response.Content.ReadAsStringAsync();
                    try
                    {
                        return JsonConvert.DeserializeObject<TokenViewModel>(respo);
                    }
                    catch (JsonReaderException ex)
                    {
                        return null;//throw new ("Internal Error Occured during Json Deserialization. " + respo, ex);
                    }
                }
            }
        }
        /// <summary>
        /// User activation and de-activation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("user/activate-deactivate")]
        [Authorize]
        [HttpPut]
        public IHttpActionResult UserActivateAndDeActivate(UserViewModel model)
        {
            try
            {
                var appUser = UserManager.FindById(Convert.ToInt64(model.Id));
                if (Convert.ToBoolean(model.IsActive))
                {
                    appUser.IsActive = true;
                    UserManager.Update(appUser);
                    SendEmailForAccountActivation(model.Id, appUser.Email, model.FullName);
                    return Ok(SuccessMessage.AccountSuccess.ACTIVATED.SuccessResponse());
                }
                else
                {
                    appUser.IsActive = false;
                    UserManager.Update(appUser);
                    SendEmailForAccountDeactivation(model.Id, appUser.Email, model.FullName);
                    return Ok(SuccessMessage.AccountSuccess.DEACTIVATED.SuccessResponse());
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }
        public void SendEmailForAccountActivation(long? userId, string toEmail, string fullName)
        {
            var configData = _emailConfiguration.EmailConfigurationSelect(EmailConfigurationKey.AccountActivated.ToString());
            var emailBody = string.Format(configData.ConfigurationValue, fullName);
            MailSender.SendEmail(toEmail, EmailConstants.ACCOUNT_ACTIVATED, emailBody).Wait();
        }
        public void SendEmailForAccountDeactivation(long? userId, string toEmail, string fullName)
        {
            var configData = _emailConfiguration.EmailConfigurationSelect(EmailConfigurationKey.AccountDeactivated.ToString());
            var emailBody = string.Format(configData.ConfigurationValue, fullName);
            MailSender.SendEmail(toEmail, EmailConstants.ACCOUNT_DEACTIVATED, emailBody).Wait();
        }

        [Route("user")]
        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteUser(UserViewModel model)
        {
            try
            {
                var user = UserManager.FindById(Convert.ToInt64(model.Id));
                user.IsDeleted = true;
                user.Email = user.UserName =  user.Email + "deleted" + CommonMethods.GetUniqueKey(6);
                UserManager.Update(user);
                return Ok(SuccessMessage.AccountSuccess.DELETED.SuccessResponse());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ErrorResponse());
            }
        }

        ApplicationUser GetUser(string email)
        {

            var user = UserManager.FindByEmail(email);
            if (user != null) return user;

            return UserManager.Users.Where(x => x.PhoneNumber.Equals(email)).FirstOrDefault();

        }
        #endregion

        [AllowAnonymous]
        [HttpPost]
        [Route("user/social/register")]
        public async Task<IHttpActionResult> Register(UserViewModel model)
        {
            string roleName = UserRole.Admin;
            #region Intializing ApplicationUser
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FacebookId = model.FacebookId,
                IsFacebookConnected = model.FacebookId != null ? true : false,
                GoogleId = model.GoogleId,
                IsGoogleConnected = model.GoogleId != null ? true : false,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            #endregion
            #region Social Login
            user.EmailConfirmed = true;
            var returnVal = await SaveExternalLoginInfo(user, roleName);

            if (returnVal.UserRegistered == UserRegistered.Failed) return Ok("Failed".ErrorResponse());

            return await GetLoginJson(returnVal.User);
            #endregion
        }

        private async Task<UserDetails> SaveExternalLoginInfo(ApplicationUser user, string roleName)
        {
            var idenityresult = await UserManager.CreateAsync(user);
            UserRegistered UserRegistered;
            ApplicationUser userModel = null;
            if (!idenityresult.Succeeded)
            {
                UserRegistered = UserRegistered.AlreadyRegister;
                /*Check for user is already registered*/
                userModel = UserManager.FindByEmail(user.Email);
                if (userModel == null) UserRegistered = UserRegistered.Failed;

                if ((Convert.ToBoolean(userModel.IsFacebookConnected) && Convert.ToBoolean(user.IsFacebookConnected) && (userModel.FacebookId == user.FacebookId)) ||
                (Convert.ToBoolean(userModel.IsGoogleConnected) && Convert.ToBoolean(user.IsGoogleConnected) && (userModel.GoogleId == user.GoogleId)))
                {
                    UserRegistered = UserRegistered.AlreadyRegister;
                }
                else if (Convert.ToBoolean(user.IsGoogleConnected))
                {
                    userModel.IsGoogleConnected = user.IsGoogleConnected;
                    userModel.GoogleId = user.GoogleId;
                    await UserManager.UpdateAsync(userModel);
                }
                else if (Convert.ToBoolean(user.IsFacebookConnected))
                {
                    userModel.IsFacebookConnected = user.IsFacebookConnected;
                    userModel.FacebookId = user.FacebookId;
                    await UserManager.UpdateAsync(userModel);
                }
                else
                {
                    UserRegistered = UserRegistered.Failed;
                }
            }
            else
            {
                userModel = UserManager.FindByEmail(user.Email);
                UserRegistered = UserRegistered.NowRegitered;
                UserManager.AddToRole(user.Id, roleName);
            }
            return new UserDetails
            {
                User = userModel,
                UserRegistered = UserRegistered
            };
        }
    }
    public class UserDetails
    {
        public ApplicationUser User { get; set; }
        public UserRegistered UserRegistered { get; set; }
    }
}
