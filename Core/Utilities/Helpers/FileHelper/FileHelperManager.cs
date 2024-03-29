﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Helpers.GuidHelperr;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{

    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root, string customPath = "")
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root + customPath))
                {                          
                    Directory.CreateDirectory(root + customPath);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = customPath + guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }

}
