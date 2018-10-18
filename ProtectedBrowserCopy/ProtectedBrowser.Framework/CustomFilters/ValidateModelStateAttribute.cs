using ProtectedBrowser.Framework.GenericResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProtectedBrowser.Framework.CustomFilters
{
    /// <summary>
    /// This action filter validate the ModelState from request body. If ModelState is invalid it create error response with validation error
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute, IActionFilter
    {
        public bool CheckForModelNull { get; set; }

        public string ModelName { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (CheckForModelNull)
            {
                var obj = actionContext.ActionArguments[ModelName];

                if (obj == null)
                {
                    actionContext.Response = new HttpResponseMessage
                    {
                        Content = new ObjectContent<ApiRespone<string>>(new ApiRespone<string>
                        {
                            Data = AppConstant.Messages.MODEL_NULL_ERROR,
                            Status = false,
                            Message = "Validation Error"
                        }, new JsonMediaTypeFormatter(), "application/json"),

                    };
                }
            }

            if (!modelState.IsValid)
            {
                //get all error from modelState
                var errors = modelState.SelectMany(v => v.Value.Errors.Select(x => x.ErrorMessage)).ToList();

                if (errors.All(x => string.IsNullOrEmpty(x)))
                {
                    //if error is not found, select all exception messages from modelState
                    errors = modelState.SelectMany(v => v.Value.Errors.Select(x => x.Exception.Message)).ToList();
                }
                actionContext.Response = new HttpResponseMessage
                {
                    //create error reponse from modelState Error
                    Content = new ObjectContent<ApiRespone<List<string>>>(new ApiRespone<List<string>>
                    {
                        Data = errors,
                        Status = false,
                        Message = "Validation Error"
                    },
                    new JsonMediaTypeFormatter(),
                    "application/json"),
                    ReasonPhrase = "Invalid ModelState",
                };

            }


            base.OnActionExecuting(actionContext);
        }

    }

    public partial class AppConstant
    {
        public class Messages
        {
            public const string MODEL_NULL_ERROR = "No data submitted";
        }
    }
}
