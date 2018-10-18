using ProtectedBrowser.Domain.Category;
using ProtectedBrowser.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Blog
{
  public  class BlogModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTimeOffset> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdatedOn { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<int> TotalCount { get; set; }
        public bool IsDeleted { get; set; }
        public CategoryModel Category { get; set; }
        public FileGroupItemsModel FileGroupItem { get; set; }

        public long? FileId { get; set; }
        public string FileUrl { get; set; }
        public string FileName { get; set; }

    }
}
