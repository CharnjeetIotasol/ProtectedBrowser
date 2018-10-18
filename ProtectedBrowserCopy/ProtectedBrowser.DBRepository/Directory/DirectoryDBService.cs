using ProtectedBrowser.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Directory
{
    public class DirectoryDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }

        public long DirectoryInsert(DirectoryModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.DirectoryInsert(model.CreatedBy,model.UpdatedBy,model.IsActive,model.RootPath,model.UserName,model.Password,model.Name).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }

        }
        public void DirectoryUpdate(DirectoryModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.DirectoryUpdate(model.Id,model.CreatedBy,model.UpdatedBy,model.CreatedOn,model.UpdatedOn,model.IsDeleted,model.IsActive,model.RootPath,model.UserName,model.Password,model.Name);
            }

        }
        public List<DirectoryModel> SelectDirectory(long? id, bool? isActive = null, int? next = null, int? offset = null)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.DirectorySelect(id, isActive, next, offset).Select(x => new DirectoryModel
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
                    TotalCount = x.overall_count.GetValueOrDefault(),
                }).ToList();
            }
        }
    }
}
