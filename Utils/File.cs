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
                string? parentFolder = GetDirectoryName(currentPath);

                if (parentFolder == null)
                    throw new DirectoryNotFoundException();

                file.MoveTo(@$"{parentFolder}\{newFileName}");
            }
            catch
            {
                throw;
            }
        }

        public static string? GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public static string? GetDirectoryName(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

        public static void MakeDirectoryHidden(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if ((directoryInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    directoryInfo.Attributes |= FileAttributes.Hidden;
                }
            }
        }

        public static void MakeFileHidden(string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && System.IO.File.Exists(filename))
            {
                FileInfo fileInfo = new FileInfo(filename);
                if ((fileInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    fileInfo.Attributes |= FileAttributes.Hidden;
                }
            }
        }
    }
}