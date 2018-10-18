using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Leave
{
    public class LeaveModel
    {
        public long? Id { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string Description { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Type { get; set; }
        public long? UserId { get; set; }
        public int TotalCount { get; set; }
        public string FullName { get; set; }
    }
}
