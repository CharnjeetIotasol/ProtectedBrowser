using ProtectedBrowser.Domain.Upload;
﻿using ProtectedBrowser.Domain.Directory;//@@ADD_NEW_NAMESPACE_XML_CODE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Xml
{
    public interface IXmlService
    {
        List<FileGroupItemsModel> GetFileGroupItemsByXml(string attachmentFileXml);
        
        List<DirectoryModel> GetDirectoryByXml(string attachmentFileXml); //@@ADD_NEW_XML_CODE
    }
}

