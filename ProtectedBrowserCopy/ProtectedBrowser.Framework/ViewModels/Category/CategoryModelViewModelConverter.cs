using ProtectedBrowser.Domain.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.Framework.ViewModels.Category
{
   public static class CategoryModelViewModelConverter
    {
        public static CategoryModel ToModel(this CategoryViewModel x)
        {
            if (x == null) return new CategoryModel();
            return new CategoryModel
            {
                CreatedBy = x.CreatedBy,
                IsActive = x.IsActive,
                Name = x.CategoryName,
                IsDeleted = x.IsDeleted,
                Id = x.CategoryId,
                UpdatedBy = x.UpdatedBy

            };
        }

        public static CategoryViewModel ToViewModel(this CategoryModel x)
        {
            if (x == null) return new CategoryViewModel();
            return new CategoryViewModel
            {
                CreatedBy = x.CreatedBy,
                IsActive = x.IsActive,
                CategoryName = x.Name,
                CategoryId = x.Id,
                CreateOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                OverAllCount = x.TotalCount,
                UpdatedBy = x.UpdatedBy

            };
        }
    }
}
