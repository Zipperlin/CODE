﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstrumentOperation.FileManager.CommucationFile
{
    public class FFFile:InstrumentFile
    {
        public override string replacestring(string oldString,string pattern,string newString)
        {         
            return Regex.Replace(oldString, pattern, newString);
        }
    }
}
