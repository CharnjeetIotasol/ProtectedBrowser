using ProtectedBrowser.Common.Extensions;
using ProtectedBrowser.Domain.DailyWorkSetting;
using ProtectedBrowser.Domain.DummyFileUpload;
using ProtectedBrowser.Domain.Upload;
using ProtectedBrowser.Framework.ViewModels.DailyWorkSetting;
using ProtectedBrowser.Framework.ViewModels.DummyFileUpload;
using ProtectedBrowser.Framework.ViewModels.Upload;
using System.Linq;

namespace ProtectedBrowser.Framework.WebExtensions
{
    public static class ViewModelToModel
    {
        public static DailyWorkSettingModel ToModel(this DailyWorkSettingViewModel x)
        {
            if (x == null) return new DailyWorkSettingModel();
            return new DailyWorkSettingModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                StartLunchTime = x.StartLunchTime,
                Saturday = x.Saturday,
                Monday = x.Monday,
                Friday = x.Friday,
                EndTime = x.EndTime,
                EndLunchTime = x.EndLunchTime,
                StartTime = x.StartTime,
                Sunday = x.Sunday,
                Thursday = x.Thursday,
                Tuesday = x.Tuesday,
                Wednesday = x.Wednesday
            };
        }
        public static FileGroupItemsModel ToModel(this FileGroupItemsViewModel x)
        {
            if (x == null) return new FileGroupItemsModel();
            return new FileGroupItemsModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                Filename = x.Filename,
                MimeType = x.MimeType,
                Thumbnail = x.Thumbnail,
                Size = x.Size,
                Path = x.Path,
                OriginalName = x.OriginalName,
                OnServer = x.OnServer,
                TypeId = x.TypeId,
                Type=x.Type
            };
        }
        public static DummyTableForFileModel ToModel(this DummyTableForFileViewModel x)
        {
            if (x == null) return new DummyTableForFileModel();
            return new DummyTableForFileModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                Name = x.Name,
                FileGroupItems=x.FileGroupItems != null ? x.FileGroupItems.Select(y => y.ToModel()).ToList() : null,
                FileGroupItem = x.FileGroupItem != null ? x.FileGroupItem.ToModel() : null,
                FileGroupItemsXml =x.FileGroupItems.XmlSerialize(),
            };
        }
    }
}


