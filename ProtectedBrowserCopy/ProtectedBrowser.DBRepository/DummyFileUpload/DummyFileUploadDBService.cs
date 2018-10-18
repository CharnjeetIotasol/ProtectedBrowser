using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.DummyFileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.DummyFileUpload
{
    public class DummyFileUploadDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }

        public long DummyTableForFileInsert(DummyTableForFileModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.DummyTableForFileSave(model.Name, model.CreatedBy).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }
        }
        public void DummyTableForFileUpdate(DummyTableForFileModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.DummyTableForFileUpdate(model.Name, model.UpdatedBy, model.IsDeleted, model.IsActive, model.Id);
            }
        }
        public List<DummyTableForFileModel> DummyTableForFileSelect(SearchParam param)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.DummyTableForFileSelect(param.Id, param.Type, param.Next, param.Offset).Select(x => new DummyTableForFileModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    IsActive=x.IsActive,
                    CreatedUser = new Domain.CreatedUserModel
                    {
                        UserId = x.CreatedBy,
                        FirstName = x.CreatedByFirstName,
                        LastName = x.CreatedByLastName,
                        PhoneNumber = x.CreatedByPhoneNumber
                    },
                    UpdatedUser = new Domain.UpdatedUserModel
                    {
                        UserId = x.UpdatedBy,
                        FirstName = x.UpdatedByFirstName,
                        LastName = x.UpdatedByLastName,
                        PhoneNumber = x.UpdatedByPhoneNumber
                    },
                    FileGroupItemsXml=x.FileGroupItemsXml
                }).ToList();
            }
        }
    }
}
