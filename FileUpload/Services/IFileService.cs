﻿using FileUpload.Entities;

namespace FileUpload.Services
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);

        public Task PostMultiFileAsync(List<FileUploadModel> fileData);
        public Task PostMultiFileAsync(List<IFormFile> fileData);
        public Task DownloadFileById(int fileName);
    }
}
