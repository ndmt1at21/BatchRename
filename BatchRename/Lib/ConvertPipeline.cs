using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchRename.Model;
using PluginContract;

namespace BatchRename.Lib
{
    public class RuleData
    {
        public IRenameRule RenameRule;
        public IRuleParameter Paramter;
    }

    public class ConvertPipeline
    {
        //private IEnumerable<RuleData> _rules { get; set; }

        //public ConvertPipeline()
        //{
        //    _rules = new List<RuleData>();
        //}

        //public ConvertPipeline(IEnumerable<RuleData> rules)
        //{
        //    _rules = rules;
        //}

        //public void AddRuleData(RuleData ruleData)
        //{
        //    _rules.Append(ruleData);
        //}

        //public IEnumerable<FileInfor> Convert(IEnumerable<FileInfor> files)
        //{
        //    List<FileInfor> results = new List<FileInfor>();
        //    FileInfor[] cloneFiles = files.ToArray();

        //    _rules.Select(rule =>
        //    {
        //        IRenameRule renameRule = rule.RenameRule;
        //        IRuleParameter paramter = rule.Paramter;

        //        cloneFiles = rule.RenameRule.Convert(cloneFiles, rule.Paramter);
        //        return rule;
        //    });

        //    return cloneFiles;
        //}
    }
}
