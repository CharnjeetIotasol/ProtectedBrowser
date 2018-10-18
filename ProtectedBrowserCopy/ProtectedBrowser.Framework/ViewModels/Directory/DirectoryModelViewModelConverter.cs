using ProtectedBrowser.Domain.Directory;
using ProtectedBrowser.Framework.ViewModels.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.WebExtensions
{
    public static class DirectoryModelViewModelConverter
    {
        public static DirectoryViewModel ToViewModel(this DirectoryModel x)
        {
            if (x == null) return new DirectoryViewModel();
            return new DirectoryViewModel
            {
        			Id = x.Id,
        			CreatedBy = x.CreatedBy,
        			UpdatedBy = x.UpdatedBy,
        			CreatedOn = x.CreatedOn,
        			UpdatedOn = x.UpdatedOn,
        			IsDeleted = x.IsDeleted,
        			IsActive = x.IsActive,
        			RootPath = x.RootPath,
        			UserName = x.UserName,
        			Password = x.Password,
        			Name = x.Name,
				TotalCount=x.TotalCount
            };
        }
		
		 public static DirectoryModel ToModel(this DirectoryViewModel x)
        {
            if (x == null) return new DirectoryModel();
            return new DirectoryModel
            {
        			Id = x.Id,
        			CreatedBy = x.CreatedBy,
        			UpdatedBy = x.UpdatedBy,
        			CreatedOn = x.CreatedOn,
        			UpdatedOn = x.UpdatedOn,
        			IsDeleted = x.IsDeleted,
        			IsActive = x.IsActive,
        			RootPath = x.RootPath,
        			UserName = x.UserName,
        			Password = x.Password,
        			Name = x.Name,
            };
        }
    }
}
