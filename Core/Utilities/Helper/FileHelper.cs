using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.FileManager
{
    public class FileHelper : IFileHelper
    {
        static string _directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string _path = @"Images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(_directory + _path))
            {
                Directory.CreateDirectory(_directory + _path);
            }
            using (FileStream fileStream = File.Create(_directory + _path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (_path + newFileName).Replace("\\", "/");
        }

        public static void Delete(string imagePath)
        {
            if (File.Exists(_directory + imagePath.Replace("/", "\\"))
                && Path.GetFileName(imagePath) != "default.jpg")
            {
                File.Delete(_directory + imagePath.Replace("/", "\\"));
            }
        }

        public IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("No File.");
        }
    }
}