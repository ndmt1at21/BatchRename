using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class File
    {
        public static void RenameFile(string currentPath, string newFileName)
        {
            FileInfo file = new FileInfo(currentPath);

            if (file.Exists)
            {
                try
                {
                    var groups = Regex.Match(currentPath, @"^(.+)[\/\\]([^\/]+)$").Groups;

                    if (groups.Count != 3)
                        throw new NotSupportedException();

                    file.MoveTo(@$"{groups[1]}\{newFileName}");
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}