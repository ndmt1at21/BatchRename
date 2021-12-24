using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuffixRule
{
    class AddSuffixRule : IRenameRule
    {
        public string Id => "AddSuffix";

        public AddSuffixParamter _parameter { get; set; }

        public void SetParameter(IRuleParameter ruleParameter)
        {
            _parameter = (AddSuffixParamter)ruleParameter;
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_parameter == null)
                return null;

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName + _parameter.Suffix
            };
        }

        public string GetStatement()
        {
            if (_parameter == null)
                return null;

            return $"Add prefix {_parameter.Suffix} to file name";
        }
    }
}
