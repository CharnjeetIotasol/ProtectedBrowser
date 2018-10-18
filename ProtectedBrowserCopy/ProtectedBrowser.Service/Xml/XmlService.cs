using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain.Upload;
using System.Xml.Linq;
using ProtectedBrowser.Common.Extensions;
using ProtectedBrowser.Domain.Directory;

namespace ProtectedBrowser.Service.Xml
{
    public class XmlService : IXmlService
    {
        #region Attachement file XML to List

        public List<FileGroupItemsModel> GetFileGroupItemsByXml(string attachmentFileXml)
        {
            if (string.IsNullOrEmpty(attachmentFileXml)) return new List<FileGroupItemsModel>();
            return XDocument.Parse(attachmentFileXml).Element("root").Elements("AF").Select(x => new FileGroupItemsModel
            {
                Id = x.Element("Id").GetValue<long>(),
                CreatedBy = x.Element("CreatedBy").GetValue<long>(),
                UpdatedBy = x.Element("UpdatedBy").GetValue<long>(),
                CreatedOn = x.Element("CreatedOn").GetDateOffset(),
                IsDeleted = x.Element("CreatedBy").GetBoolVal(),
                IsActive = x.Element("IsActive").GetBoolVal(),
                UpdatedOn = x.Element("UpdatedOn").GetDateOffset(),
                Filename = x.Element("Filename").GetStrValue(),
                MimeType = x.Element("MimeType").GetStrValue(),
                Thumbnail = x.Element("Thumbnail").GetStrValue(),
                Path = x.Element("Path").GetStrValue(),
                OriginalName = x.Element("OriginalName").GetStrValue(),
                OnServer = x.Element("OnServer").GetStrValue(),
                TypeId = x.Element("TypeId").GetValue<long>(),
                Type = x.Element("Type").GetStrValue(),
                Size = x.Element("Size").GetValue<long>(),
            }).ToList();
        }
        
        public List<DirectoryModel> GetDirectoryByXml(string attachmentFileXml)
{
    if (string.IsNullOrEmpty(attachmentFileXml)) return new List<DirectoryModel>();
    return XDocument.Parse(attachmentFileXml).Element("root").Elements("R").Select(x => new DirectoryModel
    {
			  	Id = x.Element("Id").GetValue<long>(),
			  	CreatedBy = x.Element("CreatedBy").GetValue<long>(),
			  	UpdatedBy = x.Element("UpdatedBy").GetValue<long>(),
			  	CreatedOn = x.Element("CreatedOn").GetDateOffset(),
			  	UpdatedOn = x.Element("UpdatedOn").GetDateOffset(),
			  	IsDeleted = x.Element("IsDeleted").GetBoolVal(),
			  	IsActive = x.Element("IsActive").GetBoolVal(),
			  	RootPath = x.Element("RootPath").GetStrValue(),
			  	UserName = x.Element("UserName").GetStrValue(),
			  	Password = x.Element("Password").GetStrValue(),
			  	Name = x.Element("Name").GetStrValue(),
    }).ToList();
}//@@ADD_NEW_XML_CODE
        #endregion
    }
}

