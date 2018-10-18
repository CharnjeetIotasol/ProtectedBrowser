using ProtectedBrowser.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Exception
{
   public class ExceptionDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public void ExceptionLogInsert(ExceptionModel exception)
        {
            using (var dbctx = DbContext)
            {
                dbctx.InsertExceptionLog(exception.Source, exception.Message, exception.StackTrace, exception.Uri, exception.Method, exception.CreatedBy);
                
            }
        }
    }
}
