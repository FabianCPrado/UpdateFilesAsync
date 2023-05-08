using FileUpload.Entities;
using FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _uploadService;

        public FilesController(IFileService uploadService)
        {
            _uploadService = uploadService;
        }

        /// <summary>
        /// Single File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if(fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                  _uploadService.PostFileAsync(fileDetails.FileDetails, FileType.PDF);


                return Ok();
            }
            catch (Exception)
            {
                throw;
            }         
        }



 

        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<IFormFile> dataFiles)
        {

            if (dataFiles == null)
            {
                return BadRequest();
            }     

             _uploadService.PostMultiFileAsync(dataFiles);

            return Ok();
        }

        /// <summary>
        /// Multiple File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //[HttpPost("PostMultipleFile")]
        //public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> fileDetails)
        //{
        //    if (fileDetails == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _uploadService.PostMultiFileAsync(fileDetails);

        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.DownloadFileById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
