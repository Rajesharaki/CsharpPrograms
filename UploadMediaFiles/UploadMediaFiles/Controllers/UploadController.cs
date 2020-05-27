using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadMediaFiles.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult ChunkUpload()
        {
            return View();
        }

        public IActionResult UploadFile(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var FilePath = Path.Combine(path, file.FileName);
            if (System.IO.File.Exists(FilePath))
                System.IO.File.Delete(FilePath);
            using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                file.CopyTo(fileStream);
                fileStream.Close();
            }
            Merge(file.FileName, path);
            return Json("Successfully Uploaded the File");
        }
        private SortedList<int, string> GetSortedList(string[] files)
        {
            int FileNumber = 0;
            SortedList<int, string> result = new SortedList<int, string>();
            foreach (var FileName in files)
            {
                var token = ".part_";
                var MyContent = FileName.Substring(FileName.LastIndexOf(token) + token.Length);///"1.5"
                int.TryParse(MyContent.Substring(0, MyContent.IndexOf(".")), out FileNumber);
                result.Add(FileNumber, FileName);
            }
            return result;
        }
        private void Merge(string FileName, string path)
        {
            var token = ".part_";
            var ActualFileName = FileName.Substring(0, FileName.IndexOf(token));
            var MyContent = FileName.Substring(FileName.LastIndexOf(token) + token.Length);///" 1.5"
            int TotalFileCount = 0;
            int.TryParse(MyContent.Substring(MyContent.IndexOf(".") + 1), out TotalFileCount);
            var files = Directory.GetFiles(path, "*" + ActualFileName + "*");
            var actualfilepath = Path.Combine(path, ActualFileName);
            if (files.Length == TotalFileCount)
            {
                lock (this)
                {
                    FileStream fileChunk = null;
                    var fileList = GetSortedList(files).ToList();
                    FileStream ActualFileStream = new FileStream(actualfilepath, FileMode.Create);
                    foreach (var chunk in fileList)
                    {
                        fileChunk = new FileStream(chunk.Value, FileMode.Open);
                        fileChunk.CopyTo(ActualFileStream);
                    }
                    fileChunk.Close();
                    fileChunk.Flush();
                    ActualFileStream.Close();
                    ActualFileStream.Flush();
                }
            }
        }
    }
}
