using Microsoft.AspNetCore.Http;
using ReCapProject.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReCapProject.Core.Utilities.Helpers.FileHelpers
{
    public class FileHelpers
    {
        public static IResult Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return new SuccessResult("File Silindi");
            }

            return new ErrorResult("Böyle bir dosya bulunmamaktadır");
        }

        public static IDataResult<string> Update(IFormFile formFile , string sourcePath , string destinationPath)
        {
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
            }

            return Upload(formFile, destinationPath);
        }

        public static IDataResult<string> Upload(IFormFile formFile, string path)
        {
            if(formFile.Length > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string extention = Path.GetExtension(formFile.FileName);
                string guid = GetUniquePath();
                string filePath = Path.Combine(path, guid) + extention;
                string forDatabase = Path.Combine("Uploads\\Images\\", guid) + extention;

                using (FileStream fileSteam = File.Create(filePath))
                {
                    formFile.CopyTo(fileSteam);
                    fileSteam.Flush();

                    return new SuccessDataResult<string>(forDatabase, "Image was uploaded succesfully");
                }
            }

            return new ErrorDataResult<string>("An error occured while Image uploading process");
        }

        private static string GetUniquePath()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
