using IotasmartBuild.Framework.ViewModels.Category;
using ProtectedBrowser.Domain.Blog;
using ProtectedBrowser.Framework.WebExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.Framework.ViewModels.Blog
{
    public static class BlogModelViewModelConverter
    {
        public static BlogModel ToModel(this BlogViewModel x)
        {
            if (x == null) return new BlogModel();
            return new BlogModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsActive = x.IsActive,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                Category = x.Category != null ? x.Category.ToModel() : null,
                FileGroupItem = x.FileGroupItem != null ? x.FileGroupItem.ToModel() : null,
                FileId=x.FileId,
                FileName=x.FileName,
                FileUrl=x.FileUrl,
                CategoryName=x.CategoryName,
                IsDeleted=x.IsDeleted
            };
        }

        public static BlogViewModel ToViewModel(this BlogModel x)
        {
            if (x == null) return new BlogViewModel();
            return new BlogViewModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsActive = x.IsActive,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                Category = x.Category != null ? x.Category.ToViewModel() : null,
                FileGroupItem = x.FileGroupItem != null ? x.FileGroupItem.ToViewModel() : null,
                FileId = x.FileId,
                FileName = x.FileName,
                FileUrl = x.FileUrl,
                CategoryName=x.CategoryName,
                IsDeleted = x.IsDeleted
            };
        }
    }
}
