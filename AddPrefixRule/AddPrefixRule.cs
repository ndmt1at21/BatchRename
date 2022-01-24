using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPrefixRule
{
    public class AddPrefixRule : IRenameRule
    {
        public string Id => "AddPrefix";

        private AddPrefixParamter _parameter { get; set; }

        public void SetParameter(IRuleParameter parameter)
        {
            _parameter = (AddPrefixParamter)parameter;
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_parameter == null)
                throw new ArgumentException("Invalid parameter");

            return new FileInfor
            {
                Dir = file.Dir,
                FileName = _parameter.Prefix + file.FileName,
                Extension = file.Extension
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public string GetStatement()
        {
            if (_parameter == null)
                return null;

            return $"Add prefix \"{_parameter.Prefix}\" to file name";
        }
    }
}
