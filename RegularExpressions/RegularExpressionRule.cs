using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace RegularExpressions
{
    public class RegularExpressionRule : IRenameRule
    {
        public string Id => "RegularExpression";
        private RegularExpressionParameter _parameter { get; set; }

        public FileInfor Convert(FileInfor file)
        {
            if (_parameter == null)
                throw new ArgumentException("Invalid parameter");

            Regex Expression = new Regex(_parameter.Regex);
            string newFileName = Expression.Replace(file.FileName, _parameter.ReplaceString);

            return new FileInfor
            {
                Dir = file.Dir,
                FileName = newFileName,
                Extension = file.Extension
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            throw new NotImplementedException();
        }

        public string GetStatement()
        {
            return $"Replace string that match a Regex pattern \"{_parameter.Regex}\" with \"{_parameter.ReplaceString}\"";
        }

        public void SetParameter(IRuleParameter ruleParameter)
        {
            _parameter = (RegularExpressionParameter)ruleParameter;
        }
    }
}
