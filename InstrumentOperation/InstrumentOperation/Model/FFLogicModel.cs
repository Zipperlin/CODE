using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentOperation.Common;
using InstrumentOperation.FileManager;
using System.Text.RegularExpressions;

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
                string NewfilePath = filePath.Insert(filePath.LastIndexOf('.'), "_bak");

                string[] content=m_file.ReadFile2Array(NewfilePath);
                ReplaceBasicInfo(content, info,NewfilePath);

                
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

        private void ReplaceBasicInfo(string[] content, S_ManufactureInfo info, string NewfilePath)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if(content[i].Contains("FB_VFD_VENDOR_NAME"))
                {
                    content[i] = m_file.replacestring(content[i], @"(?<="")(\w+?)(?="")", info.ManufactureName);
                }            
                else if(content[i].Contains("ulManufacId"))
                {
                    content[i] = m_file.replacestring(content[i], @"(\w+?)(?=,)", info.ManufactureID);
                }
                else if (content[i].Contains("uDevType"))
                {
                    content[i] = m_file.replacestring(content[i], @"(\w+?)(?=,)", info.DevType);
                }
                else if(content[i].Contains("FIRMWARE_INFO gsFirmwareInfo"))
                {
                    content[i+5] = m_file.replacestring(content[i + 5], @"(?<="")(\w+?)(?="")", info.DevID);
                }
                else if (content[i].Contains("USIGN8 SM_DEFAULT_PD_TAG[]"))
                {
                    Regex re = new Regex("(?<=\").*?(?=\")", RegexOptions.None);
                    content[i] = re.Replace(content[i], info.DevName);
                }
                else
                {

                }
            }

            m_file.WriteFile(NewfilePath, content);
        }

        private void ReplaceFuncConfig()
        {
            //string[] content
        }
    }
}
