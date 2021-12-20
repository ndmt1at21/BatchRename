using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchRename.Model;
using PluginContract;

namespace BatchRename.Lib
{
    public delegate void ConvertResultHandler(FileInfor file, string errMessage);

    public class ConvertPipeline
    {
        private List<IRenameRule> _rules { get; set; }

        public ConvertPipeline()
        {
            _rules = new List<IRenameRule>();
        }

        public ConvertPipeline(List<IRenameRule> rules)
        {
            _rules = rules;
        }

        public void AddRuleData(IRenameRule rule)
        {
            _rules.Add(rule);
        }

        public void Convert(List<FileInfor> files, ConvertResultHandler OnFileConverted)
        {
            FileInfor[] cloneFiles = files.ToArray();

            foreach (FileInfor file in cloneFiles)
            {
                try
                {
                    FileInfor result = ConvertFile(file);
                    Debug.WriteLine("Convert success");
                    OnFileConverted(result, null);
                }
                catch (Exception ex)
                {
                    OnFileConverted(null, ex.Message);
                }
            }
        }

        private FileInfor ConvertFile(FileInfor file)
        {
            FileInfor result = file;

            foreach (IRenameRule rule in _rules)
            {
                result = rule.Convert(result);
            }

            return result;
        }
    }
}
