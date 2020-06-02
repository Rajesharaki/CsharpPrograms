using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadMediaFiles.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadMediaFilesController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        public UploadMediaFilesController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 1024 * 1024 * 200)]
        [RequestSizeLimit(1024 * 1024 * 200)]
        public IActionResult Upload()
        {
            foreach (var file in Request.Form.Files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = file.FileName;
                    if (!Directory.Exists(_env.WebRootPath + "//UploadedFiles//"))
                    {
                        Directory.CreateDirectory(_env.WebRootPath + "//UploadedFiles//");

                    }
                    var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles");
                    var path = Path.Combine(directory, fileName);
                    try
                    {
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);

                        using (FileStream chunkFiles = System.IO.File.Create(path))
                        {
                            file.CopyTo(chunkFiles);
                        }
                        MergeFile(path);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message.ToString());
                    }
                }
            }
            return Ok("SuccessFully Uploaded");
        }

        private readonly static Object _locker = new Object();
        public bool MergeFile(string FileName)
        {
            bool rslt = false;
            string partToken = ".part_";

            //actual FileName
            string baseFileName = FileName.Substring(0, FileName.IndexOf(partToken));

            //TotalNumber of ChunkFiles

            string[] splitFile = FileName.Split('.');
            int totalPart;
            int.TryParse(splitFile[splitFile.Length - 1], out totalPart);

            // get a list of all file parts in the temp folder  
            string Searchpattern = Path.GetFileName(baseFileName) + partToken + "*";
            string[] FilesList = Directory.GetFiles(Path.GetDirectoryName(FileName), Searchpattern);
            if (FilesList.Count() == totalPart)
            {
                SortedList<double, string> fileList = new SortedList<double, String>();
                var SortedFiles = this.SortedFiles(FilesList).ToList();

                var MergeOrder = SortedFiles.OrderBy(s => s.Key).ToList();
                using (FileStream FS = new FileStream(baseFileName, FileMode.Create))
                {
                    foreach (var chunk in MergeOrder)
                    {
                        try
                        {
                            lock (_locker)
                            {
                                using (FileStream chunkFile = new FileStream(chunk.Value, FileMode.Open))
                                {
                                    chunkFile.CopyTo(FS);
                                }
                                System.IO.File.Delete(chunk.Value);
                            }
                        }
                        catch (IOException ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }
                    }
                }
                rslt = true;
            }
            return rslt;
        }
        private SortedList<double, string> SortedFiles(string[] files)
        {
            SortedList<double, string> fileList = new SortedList<double, string>();
            foreach (var FileName in files)
            {

                var part = ".part_";
                var substr = FileName.Substring(FileName.IndexOf(part));
                string[] splitPart = substr.Split('_');
                double fileNumber = 0;
                double.TryParse(splitPart[splitPart.Length - 1], out fileNumber);
                fileList.Add(fileNumber, FileName);
            }
            return fileList;
        }
    }
}
