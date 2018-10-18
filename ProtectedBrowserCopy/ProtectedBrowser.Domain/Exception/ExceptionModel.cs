using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Exception
{
    public class ExceptionModel
    {
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Uri { get; set; }
        public string Method { get; set; }
        public long? CreatedBy { get; set; }
    }
}
