using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchRename.Model;
using PluginContract;

namespace BatchRename.Lib
{
    public delegate void ConvertResultHandler(NodeConvertModel file, string errMessage);

    public class ConvertPipeline
    {
        private List<IRenameRule> _rules { get; set; }
        private PreventDuplicateRenameRule _preventDuplicateRule { get; set; }

        public ConvertPipeline()
        {
            _rules = new List<IRenameRule>();
            _preventDuplicateRule = new PreventDuplicateRenameRule();
        }

        public ConvertPipeline(List<IRenameRule> rules)
        {
            _rules = rules;
            _preventDuplicateRule = new PreventDuplicateRenameRule();
        }

        public void AddRuleData(IRenameRule rule)
        {
            _rules.Add(rule);
        }

        public void Convert(List<NodeConvertModel> files, ConvertResultHandler OnFileConverted)
        {
            Task.Run(() =>
            {
                NodeConvertModel[] cloneFiles = files.ToArray();

                foreach (NodeConvertModel file in cloneFiles)
                {
                    try
                    {
                        FileInfor fileInfor = new FileInfor
                        {
                            Dir = file.Node.Path,
                            Extension = file.Node.Extension,
                            FileName = file.Node.Name
                        };

                        FileInfor fileInforResult = ConvertFile(fileInfor);

                        NodeConvertModel result = file;
                        result.Node.Path = fileInforResult.Dir;
                        result.Node.Extension = fileInforResult.Extension;
                        result.NewName = $"{fileInforResult.FileName}{fileInforResult.Extension}";

                        OnFileConverted(result, null);
                    }
                    catch (Exception ex)
                    {
                        OnFileConverted(file, ex.Message);
                    }
                }
            });
        }

        private FileInfor ConvertFile(FileInfor file)
        {
            FileInfor result = file;

            foreach (IRenameRule rule in _rules)
            {
                result = rule.Convert(result);
            }

            result = _preventDuplicateRule.Convert(result);

            return result;
        }
    }
}
