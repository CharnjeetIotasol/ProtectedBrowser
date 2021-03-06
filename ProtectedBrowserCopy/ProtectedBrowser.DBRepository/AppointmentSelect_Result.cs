//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProtectedBrowser.DBRepository
{
    using System;
    
    public partial class AppointmentSelect_Result
    {
        public long Id { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public System.DateTimeOffset CreatedOn { get; set; }
        public System.DateTimeOffset UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTimeOffset> AppointmentDate { get; set; }
        public string Note { get; set; }
        public Nullable<long> ToUserId { get; set; }
        public Nullable<long> FromUserId { get; set; }
        public bool IsCancel { get; set; }
        public string CancellationReason { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<bool> isAppointmentDone { get; set; }
        public string Status { get; set; }
        public Nullable<int> overall_count { get; set; }
        public string FromUserFirstName { get; set; }
        public string FromUserLastName { get; set; }
        public string FromUserEmail { get; set; }
        public string FromUserPhoneNumber { get; set; }
        public string ToUserFirstName { get; set; }
        public string ToUserLastName { get; set; }
        public string ToUserEmail { get; set; }
        public string ToUserPhoneNumber { get; set; }
        public string UpdatedByFirstName { get; set; }
        public string UpdatedByLastName { get; set; }
        public string UpdatedByPhoneNumber { get; set; }
        public string CreatedByFirstName { get; set; }
        public string CreatedByLastName { get; set; }
        public string CreatedByPhoneNumber { get; set; }
    }
}
