using System.Web.Http.Filters;
using System.Net;
using System.Web.UI.WebControls;
using System.Net.Http;
using ProtectedBrowser.Service.Exception;
using ProtectedBrowser.Domain.Exception;
using System.Web;

namespace ProtectedBrowser.Framework.CustomFilters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        //private IExceptionService _IExceptionService;
        //public CustomExceptionFilter(IExceptionService exceptionService)
        //{
        //    _IExceptionService = exceptionService;
        //}
        
        public async override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            ExceptionModel exception = new ExceptionModel();
            exception.Message = actionExecutedContext.Exception.Message;
            exception.Source = actionExecutedContext.Exception.Source;
            exception.StackTrace = actionExecutedContext.Exception.StackTrace;
            exception.Method = actionExecutedContext.Request.Method.ToString();
            exception.Uri = actionExecutedContext.Request.RequestUri.ToString();
            ExceptionService obj = new ExceptionService();
            obj.InsertLog(exception);

            //We can log this exception message to the file or database.  
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator.",
            };
            actionExecutedContext.Response = response;
        }
    }
}
