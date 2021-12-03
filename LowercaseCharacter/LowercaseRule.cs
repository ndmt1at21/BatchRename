﻿using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowercaseCharacter
{
    public class LowercaseRule : IRenameRule
    {
        public string Id => "ToLowercase";

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName.ToLower()
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            return $"To lowercase file name {file.FileName}";
        }
    }
}
