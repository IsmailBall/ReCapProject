using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public class DirectoryPath
    {
        public static string GetCarImagesRouter()
        {
            string ImagesPath = "wwwroot\\Uploads\\Images\\";

            return ImagesPath;
        }

        public static string GetDefaultImagesRouter()
        {
            return GetCarImagesRouter() + @"\DefaultImage.jpg";
        }
    }
}
