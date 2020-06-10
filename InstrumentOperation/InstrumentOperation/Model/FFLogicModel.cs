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

        private string filePath;
        #endregion

        public FFLogicModel(string path)
        {
            filePath = path;
        }

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
        public bool FFGenerateBasicCode(S_ManufactureInfo info)
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            if(m_file.IsFileExisted(filePath))
            {
                string[] content=m_file.ReadFile2Array(filePath);
                ReplaceBasicInfo(content, info);
                m_file.WriteFile(filePath, content);
            }
            
            return false;
        }

        public bool FFGenerateFuncCode()
        {
            return false;
        }

        public bool FFGenerateTransferCode()
        {
            return false;
        }

        private void ReplaceBasicInfo(string[] content, S_ManufactureInfo info)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if(content[i].Contains("FB_VFD_VENDOR_NAME"))
                {
                    content[i] = m_file.replacestring(content[i], @"(?<="")(\w+?)(?="")", info.ManufactureName);
                }            
                else if(content[i].Contains("// ulManufacId"))
                {

                }
                //else if()
                //{

                //}
                //else if()
                //{

                //}
            }
        }

        private void ReplaceFuncConfig()
        {
            //string[] content
        }
    }
}
