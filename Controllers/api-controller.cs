using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace vuenetcore.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("hello")]
        [HttpGet]
        public IActionResult Hello()
        {
            var msg = new { Message = "SEKEKOs place ROCKS!!!" };
            return this.Ok(msg);
        }

        [Route("UploadMultipleFiles")]
        [HttpPost]
        public IActionResult UploadMultipleFiles(List<IFormFile> files)
        {
            //Do something with the files here. 
            return BadRequest();
        }

        [Route("UploadSingleFile")]
        [HttpPost]
        public IActionResult UploadSingleFile(IFormFile oneFile, string customerId, string year )
        {

            PostToAzureStorage(oneFile);

            return Ok();
        }

        private void PostToAzureStorage(IFormFile oneFile){
            //Connect to Azure
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=taxportal;AccountKey=P2+0Y0ltoflrcO4b8f7TFwneuAdn4c85h/VxAfPrsZgxNCgMyIQHOU/oQEKgt0C4DOeFsoWBVe6hGs4W9iqH9w==;EndpointSuffix=core.windows.net");

            // Create a reference to the file client.
            CloudFileClient azureFileClient = storageAccount.CreateCloudFileClient(); 

            // Get a reference to the file share we created previously.
            CloudFileShare share = azureFileClient.GetShareReference("taxfiles");     
            CloudFileDirectory rootDir = share.GetRootDirectoryReference();
            CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("files");
            CloudFile file = sampleDir.GetFileReference(oneFile.FileName);

            Stream fileStream = oneFile.OpenReadStream();

            file.UploadFromStreamAsync(fileStream);
            fileStream.Dispose();

        }
    }
}
