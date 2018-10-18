using ProtectedBrowser.Domain.DailyWorkSetting;
using ProtectedBrowser.Domain.DummyFileUpload;
using ProtectedBrowser.Domain.Upload;
using ProtectedBrowser.Domain.Users;
using ProtectedBrowser.Framework.ViewModels.DailyWorkSetting;
using ProtectedBrowser.Framework.ViewModels.DummyFileUpload;
using ProtectedBrowser.Framework.ViewModels.Upload;
using ProtectedBrowser.Framework.ViewModels.User;
using System.Linq;

namespace ProtectedBrowser.Framework.WebExtensions
{
    public static class ModelToViewModel
    {
        public static DailyWorkSettingViewModel ToViewModel(this DailyWorkSettingModel x)
        {
            if (x == null) return new DailyWorkSettingViewModel();
            return new DailyWorkSettingViewModel
            {
                Id = x.Id,
                UpdatedBy = x.UpdatedBy,
                CreatedBy = x.CreatedBy,
                Wednesday = x.Wednesday,
                Tuesday = x.Tuesday,
                Thursday = x.Thursday,
                Sunday = x.Sunday,
                StartTime = x.StartTime,
                EndLunchTime = x.EndLunchTime,
                EndTime = x.EndTime,
                Friday = x.Friday,
                Monday = x.Monday,
                Saturday = x.Saturday,
                StartLunchTime = x.StartLunchTime,
            };
        }
        public static FileGroupItemsViewModel ToViewModel(this FileGroupItemsModel x)
        {
            if (x == null) return new FileGroupItemsViewModel();
            return new FileGroupItemsViewModel
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
            };
        }
        public static DummyTableForFileViewModel ToViewModel(this DummyTableForFileModel x)
        {
            if (x == null) return new DummyTableForFileViewModel();
            return new DummyTableForFileViewModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                Name = x.Name,
                CreatedUser = x.CreatedUser != null ? x.CreatedUser.ToViewModel() : null,
                UpdatedUser = x.UpdatedUser != null ? x.UpdatedUser.ToViewModel() : null,
                FileGroupItems = x.FileGroupItems != null ? x.FileGroupItems.Select(y => y.ToViewModel()).ToList() : null,
                FileGroupItem = x.FileGroupItem != null ? x.FileGroupItem.ToViewModel() : null
            };
        }
        public static UserViewModel ToViewModel(this UserModel x)
        {
            if (x == null) return new UserViewModel();
            return new UserViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.FirstName + " " + x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Address=x.Address,
                City=x.City,
                Code=x.Code,
                Country=x.Country,
                CreatedBy=x.CreatedBy,
                FacebookId=x.FacebookId,
                Gender=x.Gender,
                GoogleId=x.GoogleId,
                IsActive=x.IsActive,
                IsDeleted=x.IsDeleted,
                IsFacebookConnected=x.IsFacebookConnected,
                IsGoogleConnected=x.IsGoogleConnected,
                ProfileImageUrl=x.ProfileImageUrl
            };
        }
      
    }
}
