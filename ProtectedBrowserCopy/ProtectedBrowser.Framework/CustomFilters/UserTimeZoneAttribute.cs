using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace ProtectedBrowser.Framework.CustomFilters
{
    public class UserTimeZoneAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var currUserTimeZone = actionContext.Request.Headers.FirstOrDefault(x => x.Key.Equals("userTimeZone"));
            if (currUserTimeZone.Value == null)
            {
                actionContext.ActionArguments["timeZone"] = 0;
            }
            else
            {
                int a = 0;
                if (int.TryParse(currUserTimeZone.Value.FirstOrDefault(), out a))
                    actionContext.ActionArguments["timeZone"] = a;
                else
                    actionContext.ActionArguments["timeZone"] = currUserTimeZone.Value.FirstOrDefault();
            }
            base.OnActionExecuting(actionContext);
        }

    }
}
