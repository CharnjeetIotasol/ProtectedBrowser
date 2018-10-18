using ProtectedBrowser.Framework.ViewModels.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Appointment
{
    public class AppointmentViewModel:BaseViewEntity
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("createdBy")]
        public long? CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public long? UpdatedBy { get; set; }
        [JsonProperty("createdOn")]
        public DateTimeOffset? CreatedOn { get; set; }
        [JsonProperty("updatedOn")]
        public DateTimeOffset? UpdatedOn { get; set; }
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        [JsonProperty("appointmentDate")]
        public DateTimeOffset? AppointmentDate { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("isCancel")]
        public bool? IsCancel { get; set; }
        [JsonProperty("cancellationReason")]
        public string CancellationReason { get; set; }
        [JsonProperty("startTime")]
        public TimeSpan? StartTime { get; set; }
        [JsonProperty("endTime")]
        public TimeSpan? EndTime { get; set; }
        [JsonProperty("isAppointmentDone")]
        public bool? isAppointmentDone { get; set; }
        [JsonProperty("toUserId")]
        public long? ToUserId { get; set; }
        [JsonProperty("fromUserId")]
        public long? FromUserId { get; set; }
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty("isRescheduled")]
        public bool? IsRescheduled { get; set; }
        [JsonProperty("toUser")]
        public UserViewModel ToUser { get; set; }
        [JsonProperty("fromUser")]
        public UserViewModel FromUser { get; set; }
    }
    public class AppointmentTimeSlotViewModel
    {
        [JsonProperty("startTime")]
        public string StartTime { get; set; }
        [JsonProperty("endTime")]
        public string EndTime { get; set; }
        [JsonProperty("isBooked")]
        public bool IsBooked { get; set; }
    }
}
