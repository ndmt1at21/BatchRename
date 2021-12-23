using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Lib
{
    public class DelegateDropFileFunction
    {
        //TODO: add a file list to here, using Singleton Pattern Design.
        private static List<string> _filesList = null;
        public static List<string> getFilesList()
        {
            return _filesList;
        }
        DelegateDropFileFunction(string[] list)
        {
            if (_filesList == null)
                _filesList = new List<string>(list);
            else
            {
                foreach (var file in list)
                {
                    if (!_filesList.Contains(file))
                        _filesList.Add(file);
                }
            }
        }

        public void addFiles(string[] files)
        {
            foreach (var file in files)
            {
                if (!_filesList.Contains(file))
                    _filesList.Add(file);
            }
        }

    }
}
