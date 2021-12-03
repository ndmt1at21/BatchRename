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

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParameter;

            if (parameter == null)
                throw new InvalidCastException("Invalid parameter");

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = parameter.NewExtension,
                FileName = file.FileName
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Change file extension from ${file.FileName} to ${parameter.NewExtension}";
        }
    }
}