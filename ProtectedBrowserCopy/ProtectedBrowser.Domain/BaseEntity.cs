using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain
{
    public class BaseEntity
    {
        public long? Id { get; set; }
        public CreatedUserModel CreatedUser { get; set; }
        public UpdatedUserModel UpdatedUser { get; set; }
    }
    /// <summary>
    /// It represent the common auditable field for a record
    /// </summary>
    /// 
    public class CreatedUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public long? UserId { get; set; }
    }
    public class UpdatedUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public long? UserId { get; set; }
    }
    public class AuditModel
    {
        public DateTimeOffset? OnDate { get; set; }
        public string ByUser { get; set; }
        public long? UserId { get; set; }

    }
}
