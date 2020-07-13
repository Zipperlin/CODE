using FileManager;
using InstrumentOperation.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Converter
{
    public class ConverterFileTypeUI
    {
        public static S_UIManufactureInfo ManufactureInfo2UI(S_ManufactureInfo fileInfo)
        {
            S_UIManufactureInfo sinfo = new S_UIManufactureInfo();
            sinfo.DevID = fileInfo.DevID;
            sinfo.DevName = fileInfo.DevName;
            sinfo.DevType = fileInfo.DevType;
            sinfo.ManufactureID = fileInfo.ManufactureID;
            sinfo.ManufactureName = fileInfo.ManufactureName;
            return sinfo;
        }

        public static S_UITransferItemInfo TransferItemInfo2UI(S_TransferItemInfo fileInfo)
        {
            S_UITransferItemInfo sinfo = new S_UITransferItemInfo();
            sinfo.helpInfo = fileInfo.helpInfo;
            sinfo.itemType = fileInfo.itemType;
            sinfo.paramName = fileInfo.paramName;
            sinfo.paramType = (E_UITransferParamType)fileInfo.paramType;
            sinfo.rwPriority = fileInfo.rwPriority;
            sinfo.serialNum = fileInfo.serialNum;
            sinfo.unit = fileInfo.unit;
            sinfo.VIEW1 = fileInfo.VIEW1;
            sinfo.VIEW2 = fileInfo.VIEW2;
            sinfo.VIEW3 = fileInfo.VIEW3;
            sinfo.VIEW4_1 = fileInfo.VIEW4_1;
            sinfo.VIEW4_2 = fileInfo.VIEW4_2;
            sinfo.VIEW4_3 = fileInfo.VIEW4_3;
            sinfo.VIEW4_4 = fileInfo.VIEW4_4;
            return sinfo;
        }

        public static S_UIFuncItemInfo FuncItemInfo2UI(S_FuncItemInfo fileInfo)
        {
            S_UIFuncItemInfo sinfo = new S_UIFuncItemInfo();
            sinfo.cyclePara = (E_UIFunctionParamType)fileInfo.cyclePara;
            sinfo.rangeConfigEnd = fileInfo.rangeConfigEnd;
            sinfo.rangeConfigTop = fileInfo.rangeConfigTop;
            sinfo.serialNum = fileInfo.serialNum;
            sinfo.unit = fileInfo.unit;
            return sinfo;
        }

        public static S_ManufactureInfo UIManufactureInfo2File(S_UIManufactureInfo uiInfo)
        {
            S_ManufactureInfo sinfo = new S_ManufactureInfo();
            sinfo.DevID = uiInfo.DevID;
            sinfo.DevName = uiInfo.DevName;
            sinfo.DevType = uiInfo.DevType;
            sinfo.ManufactureID = uiInfo.ManufactureID;
            sinfo.ManufactureName = uiInfo.ManufactureName;
            return sinfo;
        }

        public static S_TransferItemInfo UITransferItemInfo2File(S_UITransferItemInfo uiInfo)
        {
            S_TransferItemInfo sinfo = new S_TransferItemInfo();
            sinfo.helpInfo = uiInfo.helpInfo;
            sinfo.itemType = uiInfo.itemType;
            sinfo.paramName = uiInfo.paramName;
            sinfo.paramType = (E_TransferParamType)uiInfo.paramType;
            sinfo.rwPriority = uiInfo.rwPriority;
            sinfo.serialNum = uiInfo.serialNum;
            sinfo.unit = uiInfo.unit;
            sinfo.VIEW1 = uiInfo.VIEW1;
            sinfo.VIEW2 = uiInfo.VIEW2;
            sinfo.VIEW3 = uiInfo.VIEW3;
            sinfo.VIEW4_1 = uiInfo.VIEW4_1;
            sinfo.VIEW4_2 = uiInfo.VIEW4_2;
            sinfo.VIEW4_3 = uiInfo.VIEW4_3;
            sinfo.VIEW4_4 = uiInfo.VIEW4_4;
            return sinfo;
        }

        public static S_FuncItemInfo UIFuncItemInfo2File(S_UIFuncItemInfo uiInfo)
        {
            S_FuncItemInfo sinfo = new S_FuncItemInfo();
            sinfo.cyclePara = (E_FunctionParamType)uiInfo.cyclePara;
            sinfo.rangeConfigEnd = uiInfo.rangeConfigEnd;
            sinfo.rangeConfigTop = uiInfo.rangeConfigTop;
            sinfo.serialNum = uiInfo.serialNum;
            sinfo.unit = uiInfo.unit;
            return sinfo;
        }

        public static S_TransferFilePath UITransferPath2File(S_UITransferFilePath fileInfo)
        {
            S_TransferFilePath sinfo = new S_TransferFilePath();
            sinfo.XTBhPath = fileInfo.XTBhPath;
            sinfo.XTBCPath = fileInfo.XTBCPath;
            sinfo.XTBdPath = fileInfo.XTBdPath;
            return sinfo;
        }

        public static S_FunctionFilePath UIFunctionFilePath2File(S_UIFunctionFilePath filePath)
        {
            S_FunctionFilePath spath = new S_FunctionFilePath();
            spath.UserAppPath = filePath.UserAppPath;
            spath.FFSeriesDllPath = filePath.FFSeriesDllPath;
            spath.FFSeriesPath = filePath.FFSeriesPath;
            spath.FFSeriesTBDllPath = filePath.FFSeriesTBDllPath;
            return spath;
        }

        public static S_UIFunctionFilePath FunctionFilePath2UI(S_FunctionFilePath filePath)
        {
            S_UIFunctionFilePath spath = new S_UIFunctionFilePath();
            spath.UserAppPath = filePath.UserAppPath;
            spath.FFSeriesDllPath = filePath.FFSeriesDllPath;
            spath.FFSeriesPath = filePath.FFSeriesPath;
            spath.FFSeriesTBDllPath = filePath.FFSeriesTBDllPath;
            return spath;
        }
    }
  
}
