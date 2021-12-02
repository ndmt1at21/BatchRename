using System;
using PluginContract;
using System.Linq;

namespace AddCounterToEndRule
{
    public class AddCounterToEndRenameRule : IRenameRule
    {
        public string Id => "AddCounterToEnd";

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            AddCounterToEndParamter ruleParams = (AddCounterToEndParamter)ruleParameter;
            return this.convert(file, ruleParams);
        }


        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            AddCounterToEndParamter ruleParams = (AddCounterToEndParamter)ruleParameter;

            if (ruleParams == null)
                throw new InvalidCastException("Invalid parameter");

            bool isParameterValid = checkValidAddCounterParameter(ruleParams, files.Length);

            if (!isParameterValid)
                return files;

            return files.Select(f => this.convert(f, ruleParams)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            AddCounterToEndParamter ruleParams = (AddCounterToEndParamter)ruleParameter;

            if (ruleParams == null)
                throw new InvalidCastException("Invalid parameter");

            return $"Add count: {{ Start From: {ruleParams.StartFrom}, Step: {ruleParams.Step} }} to end of file ${file.FileName}";
        }

        private FileInfor convert(FileInfor file, AddCounterToEndParamter parameter)
        {
            int startFrom = parameter.StartFrom;
            int countLength = parameter.PartCountLength;
            char padChar = parameter.PadChar;

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
            int countLength = parameter.PartCountLength;
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
