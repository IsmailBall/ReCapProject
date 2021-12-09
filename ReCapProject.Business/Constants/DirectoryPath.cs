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
            var result = Directory.GetCurrentDirectory().Split(@"\");
            string path = "";

            foreach (var folder in result)
            {
                if (folder.Equals("ReCapProject"))
                {
                    path += folder + @"\";
                    break;
                }
                path += folder + @"\";
            }

            path += "ImagesFolder";

            return path;
        }

        public static string GetDefaultImagesRouter()
        {
            return GetCarImagesRouter() + @"\DefaultImage.jpg";
        }
    }
}
