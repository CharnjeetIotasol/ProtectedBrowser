using ProtectedBrowser.DBRepository.Exception;
using ProtectedBrowser.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Exception
{
   public class ExceptionService
    {
        public ExceptionDBService _ExceptionDBService;
        public ExceptionService()
        {
            _ExceptionDBService = new ExceptionDBService();
        }
        public void InsertLog(ExceptionModel exception )
        {
             _ExceptionDBService.ExceptionLogInsert(exception);
        }
    }
}
