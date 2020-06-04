using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentOperation.Common;
using InstrumentOperation.FileManager;

namespace InstrumentOperation.Model
{
    class FFLogicModel 
    {
        private FileFactory filefactory = new FileFactory();
        #region data
        private InstrumentFile m_file;
#endregion
        /**
         * 协议栈转换函数
         * in:
         * out:
         * result:
         */
        bool ProtocolStackTransfer()
        {
            //To do:code for tranfer
            return false;
        }

        /**
         * 代码生成函数
         */
        public bool FFGenerateCode()
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            m_file.ReadFile("");
            m_file.replacestring();
            return false;
        }   
    }
}
