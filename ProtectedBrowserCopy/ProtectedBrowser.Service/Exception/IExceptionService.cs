﻿using ProtectedBrowser.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Exception
{
   public interface IExceptionService
    {
        void InsertLog(ExceptionModel exception);
    }
}
