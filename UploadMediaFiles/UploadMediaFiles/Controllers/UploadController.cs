using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadMediaFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly static Object obj = new Object();

        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFile(IFormFile file)
        {
            lock (obj)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var FilePath = Path.Combine(path, file.FileName);

                if (!System.IO.File.Exists(FilePath))
                {
                    using (var chunkFile = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        file.CopyTo(chunkFile);
                    }
                    BindChunkFiles(file.FileName, path);
                }
            }
            return Ok("Successfully Uploaded");
        }

        private void BindChunkFiles(string FileName, string path)
        {
            //Total ChunkFiles

            string[] splitFile = FileName.Split('.');
            int totalPart;
            int.TryParse(splitFile[splitFile.Length - 1], out totalPart);

            //ActualFileName

            var actualFileName = FileName.Substring(0, FileName.IndexOf(".part"));
            var files = Directory.GetFiles(path, actualFileName + ".part_" + "*" + totalPart);

            //Actual FilePath
            var actualFilePath = Path.Combine(path, actualFileName);

            //Merge all chunk files into the actual files

            if (totalPart == files.Length)
            {
                SortedList<double, string> fileList = new SortedList<double, String>();
                var SortedFiles = this.SortedFiles(files).ToList();
                lock (obj)
                {
                    using (FileStream actualFile = new FileStream(actualFilePath, FileMode.Create))
                    {
                        foreach (var chunks in SortedFiles)
                        {
                            using (FileStream chunkFile = new FileStream(chunks.Value, FileMode.Open))
                            {
                                chunkFile.CopyTo(actualFile);
                            }
                            System.IO.File.Delete(chunks.Value);
                        }
                    }
                }
            }
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
