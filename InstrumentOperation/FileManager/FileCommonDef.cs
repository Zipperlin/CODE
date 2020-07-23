using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public enum E_FileType
    {
        e_FF_File,
        e_HART_File,
        e_PA_File,
    }

    public enum E_TransferParamType
    {
        USIGN16,
        USIGN8,
        FLOAT,
    }

    public enum E_TransferItemType
    {
        AI,
        AO,
        DI,
        DO,
        UNIT,
        NULL,
    }

    public enum E_TransferPriorityType
    {
        Read_Only,
        Write_Only,
        Read_Write,
    }

    public struct S_ManufactureInfo
    {
        public string ManufactureName;
        public string ManufactureID;
        public string DevType;
        public string DevID;
        public string DevName;
    }

    public struct S_TransferFileProperties
    {
        public string TransferName;
        public string XTBhPath;
        public string XTBCPath;
        public string XTBdPath;
    }

    public struct S_FunctionFileProperties
    {
        public int AINum;
        public int AONum;
        public int DINum;
        public int DONum;
        public int PIDNum;
        public int RANum;
        public int ISNum;
        public int SCNum;
        public int LLNum;
        public int BGNum;
 
        public string UserAppPath;
        
    }

    public struct S_DDFileProperties
    {
        public string FFSeriesDDlPath;
        public string FFSeriesPath;
        public string FFSeriesTBDllPath;

        public S_ManufactureInfo ManufactureInfo;
        public S_TransferFileProperties TransferFileProperties;
        public S_FunctionFileProperties FunctionFileProperties;
    }

    public enum E_TransferFileType
    {
        e_XTBH,
        e_XTBC,
        e_XTBD,
    }

    public enum E_FuncFileType
    {
        e_USERAPP,
    }

    public enum E_DDFileType
    {
        e_FFSeriesDll,
        e_FFSeries,
        e_FFSeriesTBDll,
    }

    public enum E_FunctionParamType
    {
        e_AI,
        e_AO,
        e_DI,
        e_DO,
        e_PID,
        e_RA,
        e_IS,
        e_SC,
        e_LL,
        e_BG,
    }

    public class S_TransferItemInfo
    {
        public string serialNum { get; set; }
        public string paramName { get; set; }
        public E_TransferParamType paramType { get; set; }
        public E_TransferItemType itemType { get; set; }
        public string unit { get; set; }
        public E_TransferPriorityType rwPriority { get; set; }
        public string VIEW1 { get; set; }
        public string VIEW2 { get; set; }
        public string VIEW3 { get; set; }
        public string VIEW4_1 { get; set; }
        public string VIEW4_2 { get; set; }
        public string VIEW4_3 { get; set; }
        public string VIEW4_4 { get; set; }
        public string helpInfo { get; set; }
    }

    public class S_FuncItemInfo
    {
        public string serialNum { get; set; }
        public E_FunctionParamType cyclePara { get; set; }
        public string rangeConfigTop { get; set; }
        public string rangeConfigEnd { get; set; }
        public string unit { get; set; }
    }
}
