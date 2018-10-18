using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain
{
    public class SearchParam
    {
        public long? Id { get; set; }
        public long? CategoryId { get; set; }
        public long? UserId { get; set; }
        public long? ToUserId { get; set; }
        public long? FromUserId { get; set; }
        public string Type { get; set; }
        public int? Next { get; set; }
        public int? Offset { get; set; }
        public DateTimeOffset? AppointmentDate { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? ToDayDate { get; set; }
    }
}
