﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstrumentOperation.FileManager.CommucationFile
{
    public class HartFile : InstrumentFile
    {
        public override string replacestring()
        {
            string oldString = "", pattern = "", newString = "";
            return Regex.Replace(oldString, pattern, newString);
        }
    }
}