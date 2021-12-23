using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace BatchRename.Lib
{
    public class PreventDuplicateRenameRule
    {
        private Dictionary<string, int> _fileFreqs { get; set; }

        public PreventDuplicateRenameRule()
        {
            _fileFreqs = new Dictionary<string, int>();
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_fileFreqs.ContainsKey(file.Dir))
            {
                _fileFreqs.Add(file.Dir, 0);
            }

            _fileFreqs[file.Dir]++;

            string newFileName =
                _fileFreqs[file.Dir] > 0
                ? $"{file.FileName} ({_fileFreqs[file.Dir]})"
                : file.FileName;

            return new FileInfor
            {
                Dir = file.Dir,
                FileName = newFileName,
                Extension = file.Extension
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(file => Convert(file)).ToArray();
        }
    }
}
