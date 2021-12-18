using System;
using PluginContract;
using System.Linq;

namespace AddCounterToEndRule
{
    public class AddCounterToEndRenameRule : IRenameRule
    {
        public string Id => "AddCounterToEnd";

        private AddCounterToEndParamter? _ruleParameter { get; set; }

        public void SetParameter(IRuleParameter ruleParameter)
        {
            _ruleParameter = (AddCounterToEndParamter)ruleParameter;
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_ruleParameter == null)
                throw new InvalidCastException("Invalid parameter");

            return convert(file);
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            if (_ruleParameter == null)
                return files;

            bool isParameterValid = checkValidAddCounterParameter(_ruleParameter, files.Length);

            if (!isParameterValid)
                return files;

            return files.Select(f => convert(f)).ToArray();
        }

        public string GetStatement(FileInfor file)
        {
            if (_ruleParameter == null)
                throw new InvalidCastException("Invalid parameter");

            return $"Add count: {{ Start From: {_ruleParameter.StartFrom}, Step: {_ruleParameter.Step} }} to end of file ${file.FileName}";
        }

        private FileInfor convert(FileInfor file)
        {
            if (_ruleParameter == null)
                return file;

            int startFrom = _ruleParameter.StartFrom;
            int countLength = _ruleParameter.PartCountLength;
            char padChar = _ruleParameter.PadChar;

            string newFileName = startFrom.ToString().PadLeft(countLength, padChar);

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = newFileName
            };
        }

        private bool checkValidAddCounterParameter(AddCounterToEndParamter parameter, int nFiles)
        {
            int startFrom = parameter.StartFrom;
            long countLength = parameter.PartCountLength;
            int step = parameter.Step;

            if (step == 0)
                return false;

            if (countLength == 0)
                return false;

            long maxCount = startFrom + step * (nFiles - 1);

            if (maxCount.ToString().Length > countLength)
                return false;

            return true;
        }
    }
}
