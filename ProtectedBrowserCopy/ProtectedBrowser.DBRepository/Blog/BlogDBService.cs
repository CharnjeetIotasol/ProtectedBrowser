using ProtectedBrowser.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Blog
{
    public class BlogDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }

        public long BlogInsert(BlogModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.BlogInsert(model.Title, model.Description, model.CategoryId, model.IsActive, model.CreatedBy, model.FileId).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }

        }
        public void BlogUpdate(BlogModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.BlogUpdate(model.Id, model.Title, model.Description, model.CategoryId, model.IsDeleted, model.IsActive, model.UpdatedBy, model.FileId);
            }

        }
        public List<BlogModel> BlogSelect(long? blogId, long? categoryId, bool? isActive = null, int? next = null, int? offset = null)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.BlogSelect(blogId, isActive, categoryId, next, offset).Select(x => new BlogModel
                {
                    IsActive = x.IsActive,
                    Title = x.Title,
                    Description = x.Description,
                    CreatedBy = x.CreatedBy,
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    UpdatedOn = x.UpdatedOn,
                    UpdatedBy = x.UpdatedBy,
                    CategoryId = x.CategoryId,
                    FileId = x.FileId,
                    FileName = x.FileName,
                    FileUrl = x.FileUrl,
                    CategoryName = x.CategoryName

                }).ToList();
            }
        }
    }
}
