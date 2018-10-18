using ProtectedBrowser.Domain.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Category
{
    public class CategoryDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }

        public long CategoryInsert(CategoryModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.CategoryInsert(model.Name, model.IsActive, model.CreatedBy).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }

        }
        public void CategoryUpdate(CategoryModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.CategoryUpdate(model.Id, model.Name, model.IsActive, model.IsDeleted, model.UpdatedBy);
            }

        }
        public List<CategoryModel> CategorySelect(long? categoryId, bool? isActive = null, int? next = null, int? offset = null)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.CategorySelect(categoryId, isActive, next, offset).Select(x => new CategoryModel
                {
                    IsActive = x.IsActive,
                    Name = x.Name,
                    CreatedBy = x.CreatedBy,
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    UpdatedOn = x.UpdatedOn,
                    TotalCount = x.overall_count.GetValueOrDefault(),
                    UpdatedBy = x.UpdatedBy

                }).ToList();
            }
        }
    }
}
