using SmartClassRoom.Domain.Models.FaceProcessing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.FaceServices
{
    public interface IStorageService
    {
        public Task UploadImage(FaceProcess faces);
        public Task DownloadImage();
        public Task DeleteImage();
    }
}
