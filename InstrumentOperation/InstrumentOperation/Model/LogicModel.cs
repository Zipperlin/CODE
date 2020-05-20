using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentOperation.Common;

namespace InstrumentOperation.Model
{
    class LogicModel
    {
        #region data
        FileManager m_fileManager=new FileManager();
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
        bool GenerateCode()
        {
            return false;
        }

        /// <summary>
        /// 替换基础信息
        /// </summary>
        /// <returns></returns>
        bool UpdateBasicInfo(string FilePath, S_ManufactureInfo info)
        {
            //判断文件是否存在
            if (!m_fileManager.IsFileExisted(FilePath))
            {
                //to do :log
                return false;
            }

            string strOldLine=m_fileManager.ReadFile(FilePath);
            string strNewLine="";

            //厂商信息
            string patternManuInfo = "[const OctString FB_VFD_VENDOR_NAME[] =\\]";      
            m_fileManager.ReplaceString(strOldLine, patternManuInfo, strNewLine);

            //厂商ID
            string patternManuID = "[const OctString FB_VFD_VENDOR_NAME[] =\\]";
            m_fileManager.ReplaceString(strOldLine, patternManuID, strNewLine);

            //设备类型
            string patternDevType = "[const OctString FB_VFD_VENDOR_NAME[] =\\]";
            m_fileManager.ReplaceString(strOldLine, patternDevType, strNewLine);

            //设备ID
            string patternDevID = "[const OctString FB_VFD_VENDOR_NAME[] =\\]";
            m_fileManager.ReplaceString(strOldLine, patternDevID, strNewLine);

            //设备名称
            string patternDevName = "[const OctString FB_VFD_VENDOR_NAME[] =\\]";
            m_fileManager.ReplaceString(strOldLine, patternDevName, strNewLine);

            return false;
        }
    }
}
