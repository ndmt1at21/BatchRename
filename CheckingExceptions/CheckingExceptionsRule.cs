using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckingExceptions
{
    class CheckingExceptionsRule : IRenameRule
    {
        public string Id => "CheckingExceptions";


        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            FileInfor[] CheckFile = files.Select(f => Convert(f, ruleParameter)).ToArray();
            char[] character = { '”', '*', ':', '<', '>', '?', '/', '|', '~', '#', '%', '&', '{', '}' };
            foreach (FileInfor file in CheckFile)
            {   
                if(file.FileName.Length>=255)
                {
                    throw new InvalidOperationException("The maximum length of the filename cannot exceed 255 characters");
                }    

                foreach(char c in character)
                {
                    if(file.FileName.Contains(c))
                    {
                        throw new InvalidOperationException("There are some characters that cannot be in the file name");
                    }    
                }    
            }
            return CheckFile;
        }

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            CheckingExceptionsParamter parameter = (CheckingExceptionsParamter)ruleParameter;

            if (parameter == null)
                return null;

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName 
            };
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            CheckingExceptionsParamter parameter = (CheckingExceptionsParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Checking exceptions done";
        }
    }
}
