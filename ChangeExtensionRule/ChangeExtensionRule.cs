using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeExtensionRule
{
    public class ChangeExtensionRule : IRenameRule
    {
        public string Id => "ChangeExtensionParamter";

        private ChangeExtensionParamter _parameter { get; set; }

        public void SetParameter(IRuleParameter ruleParameter)
        {
            _parameter = (ChangeExtensionParamter)ruleParameter;
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_parameter == null)
                throw new InvalidCastException("Invalid parameter");

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = _parameter.NewExtension,
                FileName = file.FileName
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

            return $"Change file extension to ${_parameter.NewExtension}";
        }
    }
}