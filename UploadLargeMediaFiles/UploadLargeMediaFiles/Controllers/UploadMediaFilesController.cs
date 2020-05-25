using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadLargeMediaFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadMediaFilesController : ControllerBase
    {

        private readonly IHostingEnvironment _env;
        public UploadMediaFilesController(IHostingEnvironment env)
        {
            _env = env;
        }


        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        [Route("UploadFilesAsync")]
        public async Task<IActionResult> UploadFilesAsync(List<IFormFile> files)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            try
            {
                if (files.Any())
                {
                    if (!Directory.Exists(_env.WebRootPath + "//UploadFiles//"))
                    {
                        Directory.CreateDirectory(_env.WebRootPath + "//UploadFiles//");
                    }

                    foreach (var file in files)
                    {
                        using (FileStream filestream = System.IO.File.Create(_env.WebRootPath + "//UploadFiles//" + file.FileName))
                        {
                            await file.CopyToAsync(filestream);
                            await filestream.FlushAsync();
                        }
                    }

                    timer.Stop();
                    return Ok("Successfully Uploaded with :" + timer.ElapsedMilliseconds + " milliSeconds");
                }
                else
                {
                    return NotFound("Files are Empty");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("UploadFilesUsingMultiThread")]
        public IActionResult UploadFilesUsingMultiThread(IFormFileCollection files)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            try
            {
                if (files.Any())
                {
                    if (!Directory.Exists(_env.WebRootPath + "//UploadFilesUsingMultiThread//"))
                    {
                        Directory.CreateDirectory(_env.WebRootPath + "//UploadFilesUsingMultiThread//");
                    }
                    ThreadStart[] threadStart = new ThreadStart[10];
                    Thread[] thread = new Thread[10];
                    int loop = 0;
                    foreach (var file in files)
                    {
                        loop++;
                        FileStream filestream = System.IO.File.Create(_env.WebRootPath + "//UploadFilesUsingMultiThread//" + file.FileName);
                        threadStart[loop] = new ThreadStart(() => this.CopyFiles(file, filestream));
                        thread[loop] = new Thread(threadStart[loop]);
                        thread[loop].Start();
                        filestream.Flush();
                        if (loop == 10)
                        {
                            loop = 0;
                        }
                    }
                    timer.Stop();
                    return Ok("Successfully Uploaded all files with :" + timer.ElapsedMilliseconds + " milliSeconds");
                }
                else
                {
                    return NotFound("Files are Empty");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
        }

        private void CopyFiles(IFormFile file, FileStream fileStream)
        {
            file.CopyTo(fileStream);
        }
    }
}