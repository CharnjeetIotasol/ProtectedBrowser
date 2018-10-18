using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Category
{
    public class CategoryModel
    {


        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int TotalCount { get; set; }
        public string AdminEmail { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
