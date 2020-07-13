﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentOperation.Common;
using InstrumentOperation.FileManager;
using System.Text.RegularExpressions;
using FileManager;
using InstrumentOperation.FileManager.CommucationFile;
using InstrumentOperation.Converter;

namespace InstrumentOperation.Model
{
    class FFLogicModel 
    {       
        #region data
        
        #endregion

        public FFLogicModel()
        {
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
        public bool FFGenerateBasicCode(string path, S_UIManufactureInfo info)
        {
            FFFile file = new FFFile();
            S_ManufactureInfo sinfo;
            sinfo=ConverterFileTypeUI.UIManufactureInfo2File(info);
            file.FFGenerateBasicCode(path,sinfo);
            return false;
        }

        public bool FFGenerateTransferCode(S_UITransferFilePath path,S_UITransferItemInfo info)
        {
            FFFile file = new FFFile();
            S_TransferFilePath sFilePath= ConverterFileTypeUI.UITransferPath2File(path);
            S_TransferItemInfo sinfo=ConverterFileTypeUI.UITransferItemInfo2File(info); ;

            file.FFGenerateTransferCode(sFilePath, sinfo);
            return false;
        }

        public bool FFGenerateFuncCode(S_UIFunctionFilePath path,S_UIFuncItemInfo info)
        {
            FFFile file = new FFFile();
            S_FunctionFilePath sFilePath = ConverterFileTypeUI.UIFunctionFilePath2File(path);
            S_FuncItemInfo sinfo = ConverterFileTypeUI.UIFuncItemInfo2File(info); ;

            file.FFGenerateFuncCode(sFilePath, sinfo);
            return false;
        } 
    }
}
