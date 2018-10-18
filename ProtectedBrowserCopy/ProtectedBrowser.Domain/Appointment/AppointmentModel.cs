using ProtectedBrowser.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Appointment
{
    public class AppointmentModel : BaseEntity
    {
        public long? Id { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTimeOffset? AppointmentDate { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public long? ToUserId { get; set; }
        public long? FromUserId { get; set; }
        public bool? IsCancel { get; set; }
        public string CancellationReason { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? isAppointmentDone { get; set; }
        public int TotalCount { get; set; }
        public UserModel FromUser { get; set; }
        public UserModel ToUser { get; set; }
    }
    public class AppointmentTimeSlot
    {
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsBooked { get; set; }
    }
}
