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
    
    public partial class LeaveSelect_Result
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public System.DateTimeOffset CreatedOn { get; set; }
        public System.DateTimeOffset UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTimeOffset> StartDate { get; set; }
        public Nullable<System.DateTimeOffset> EndDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<long> UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Nullable<int> overall_count { get; set; }
    }
}
