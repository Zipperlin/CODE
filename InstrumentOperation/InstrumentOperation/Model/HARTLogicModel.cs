﻿using InstrumentOperation.Common;
using InstrumentOperation.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Model
{
    class HARTLogicModel
    {
        private FileFactory m_fileFactory = new FileFactory();
        bool GenerateCode()
        {
            m_fileFactory.createFile(E_FileType.e_HART_File);
            return false;
        }
    }
}
