using ProtectedBrowser.Framework.CustomFilters;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.Directory;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.Directory;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using ProtectedBrowser.Domain.Directory;

namespace ProtectedBrowser.API
{
    [RoutePrefix("api")]
    [CustomExceptionFilter]
    public class DirectoryController : ApiController
    {
        private IDirectoryService _directoryService;
        public DirectoryController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        /// <summary>
        ///  Api use for get all Directory
        /// </summary>
        /// <returns></returns>
        [Route("Directorys")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        public IHttpActionResult GetAllDirectorys()
        {
            var directorys = _directoryService.SelectDirectory(null).Select(x => x.ToViewModel()); ;
            return Ok(directorys.SuccessResponse());
        }

 		/// <summary>
        ///  Api use for get all Active Directory with Limit and Offset 
        /// </summary>
        /// <returns></returns>
        [Route("active-directorys/{pageSize:int}/{pageNumber:int}")]
        [HttpGet]
        public IHttpActionResult ActiveDirectorys(int pageSize = 10, int pageNumber = 1)
        {
            var directorys = _directoryService.SelectDirectory(null, true, pageSize, pageNumber).Select(x => x.ToViewModel()); ;
            return Ok(directorys.SuccessResponse());
        }

        /// <summary>
        /// Api use for get directory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("directory/{id:long}")]
        [HttpGet]
        public IHttpActionResult GetDirectory(long id)
        {
            var directory = _directoryService.SelectDirectory(id).FirstOrDefault().ToViewModel();
            return Ok(directory.SuccessResponse());
        }

        /// <summary>
        /// Api use for  save directory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("directory")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPost]
        public IHttpActionResult SaveDirectory(DirectoryViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            model.UpdatedBy = User.Identity.GetUserId<long>();
            var responseId = _directoryService.DirectoryInsert(model.ToModel());
            return Ok(responseId.SuccessResponse("Directory save successfully"));
        }

        /// <summary>
        /// Api use for update directory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("directory")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [CustomExceptionFilter]
        [HttpPut]
        public IHttpActionResult UpdateDirectory(DirectoryViewModel model)
        {
            _directoryService.DirectoryUpdate(model.ToModel());
            return Ok("Directory Update successfully".SuccessResponse());
        }

        /// <summary>
        /// Api use for delete directory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("directory/{id:long}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [CustomExceptionFilter]
        [HttpDelete]
        public IHttpActionResult DeleteDirectory(long id)
        {
            DirectoryViewModel model = new DirectoryViewModel();
            model.Id = id;
            model.IsDeleted = true;
            _directoryService.DirectoryUpdate(model.ToModel());
            return Ok("Directory Deleted successfully".SuccessResponse());
        }
		
		
		[Route("getrootpath")]
		[HttpGet]
		[AllowAnonymous]
		public IHttpActionResult GetRootPath()
		{
			var directory = _directoryService.SelectDirectory(10002).FirstOrDefault().ToViewModel();
			return Ok(directory.SuccessResponse());
		}

        [Route("folderjson")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetFolderJson(string sDir)
        {
            List<RawData> Files = new List<RawData>();
            List<RawData> Folders = new List<RawData>();
            var directory = _directoryService.SelectDirectory(10002).FirstOrDefault().ToViewModel();
            string networkPath = directory.RootPath;
            NetworkCredential theNetworkCredential = new NetworkCredential(@directory.UserName, directory.Password);
            //using (new ConnectToSharedFolder(networkPath, theNetworkCredential))
            //{
                string[] files = Directory.GetFiles(sDir);
                string[] folders = Directory.GetDirectories(sDir);

                foreach (string file in files)
                {
                    string[] x = file.Split('\\');
                    string name = x[x.Length - 1];
                    var f = new RawData
                    {
                        Name = name,
                        Path = file,
                        Type = "file",
                        Ext = name.Split('.')[1]
                    };

                    Files.Add(f);
                }

                foreach (string folder in folders)
                {
                    string[] x = folder.Split('\\');
                    string name = x[x.Length - 1];
                    var f = new RawData
                    {
                        Name = name,
                        Path = folder,
                        Type = "folder",
                        Ext = ""
                    };

                    Folders.Add(f);
                }

            //}
            return Ok(new GetFilesFolder { Files = Files, Folders = Folders}.SuccessResponse());
        }


        [Route("filereader")]
		[HttpGet]
		[AllowAnonymous]
		public IHttpActionResult Base64Encode(string sDir)
		{
			FileStream fs;
			var directory = _directoryService.SelectDirectory(10002).FirstOrDefault().ToViewModel();
			string networkPath = directory.RootPath;
			NetworkCredential theNetworkCredential = new NetworkCredential(@directory.UserName, directory.Password);
			//using (new ConnectToSharedFolder(networkPath, theNetworkCredential))
			//{
				fs = File.Open(sDir, FileMode.Open);
				byte[] buffer = new byte[fs.Length];
				fs.Read(buffer, 0, buffer.Length);
				fs.Close();
				string str = Convert.ToBase64String(buffer);
				return Ok(new { stream = str }.SuccessResponse());
			//}
		}

    }

    public class ConnectToSharedFolder : IDisposable
    {
        readonly string _networkName;

        public ConnectToSharedFolder(string networkName, NetworkCredential credentials)
        {
            _networkName = networkName;

            var netResource = new NetResource
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplaytype.Share,
                RemoteName = networkName
            };

            var userName = string.IsNullOrEmpty(credentials.Domain)
                ? credentials.UserName
                : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

            var result = WNetAddConnection2(
                netResource,
                credentials.Password,
                userName,
                0);

            if (result != 0)
            {
                throw new Win32Exception(result, "Error connecting to remote share");
            }
        }

        ~ConnectToSharedFolder()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource,
            string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags,
            bool force);

        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        };

        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }
    }
}
