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
    
    public partial class DirectorySelect_Result
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public System.DateTimeOffset CreatedOn { get; set; }
        public System.DateTimeOffset UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string RootPath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> overall_count { get; set; }
    }
}
