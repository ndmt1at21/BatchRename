using System;
using System.IO;

namespace Utils
{
    public static class File
    {
        public static void RenameFile(string currentPath, string newFileName)
        {
            FileInfo file = new FileInfo(currentPath);

            if (!file.Exists)
                throw new FileNotFoundException();

            try
            {
                string parentFolder = GetDirectoryName(currentPath);

                if (parentFolder == null)
                    throw new DirectoryNotFoundException();

                file.MoveTo(@$"{parentFolder}\{newFileName}");
            }
            catch
            {
                throw;
            }
        }

        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public static string GetDirectoryName(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }
    }
}