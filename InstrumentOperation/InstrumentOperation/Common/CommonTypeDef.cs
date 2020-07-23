using FileManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Common
{
    /// <summary>
    /// E_Module
    /// </summary>
    public enum E_Module
    {
        e_FF_Module,
        e_HART_Module,
        e_PA_Module,
    }

    public enum E_UITransferParamType
    {
        FF_Discrete,        ////循环
        FF_FloatingPoint,   ////循环
        FF_Scaling,
        FF_Date,
        USIGN16,
        USIGN8,
        USIGN32,
        FLOAT,
        VisString,
        BitString,
        OctString,
    }

    public enum E_UITransferItemType
    {
        AI,
        AO,
        DI,
        DO,
        UNIT,
        NULL,
    }

    public enum E_UITransferPriorityType
    {
        Read_Only,
        Write_Only,
        Read_Write,
    }

    public enum E_UIFunctionParamType
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

    /// <summary>
    /// E_Pattern
    /// </summary>
    public enum E_Pattern
    {
        e_Pattern_ManufactureName,
    }

    /// <summary>
    /// E_Component
    /// </summary>
    public enum E_Component
    {
        e_CPU,
        e_1,
        e_2,
    }

    public struct S_ConfigInfo
    {
        public Dictionary<E_Pattern, string> ConfigPattern;
    }

    public struct S_ConfigUIInfo
    {
        public ObservableCollection<ItemTreeData> treeData;
    }

    public struct S_UITransferFileProperties
    {
        public string TransferName;
        public string XTBhPath;
        public string XTBCPath;
        public string XTBdPath;
    }

    public struct S_UIFuncFileProperties
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

    public struct S_UIDDFileProperties
    {
        public string FFSeriesDDlPath;
        public string FFSeriesPath;
        public string FFSeriesTBDllPath;
        public S_UIFuncFileProperties funcProperties;
        public S_UIManufactureInfo basicPropertis;
        public S_UITransferFileProperties transferProperties;
    }

    public class S_LisBoxItemInfo
    {
        public string imageName { get; set; }
        public string imagePath { get; set; }
    }  

    public class S_TransferTabList
    {
        public S_UITransferFileProperties sFilePath;
        public string tabHeader { get; set; }
        public ObservableCollection<S_UITransferItemInfo> tabContent { get; set; }
    }

    public class S_FuncTabList
    {
        public string tabHeader { get; set; }
        public ObservableCollection<S_FuncItemInfo> tabContent { get; set; }
    }

   

    public class CardModel
    {
        public string Header { get; set; }

        public string Content { get; set; }

        public string Footer { get; set; }
    }

    public class CoverViewDemoModel
    {
        public string ImgPath { get; set; }

        public string BackgroundToken { get; set; }
    }

    public struct S_UIManufactureInfo
    {
        public string ManufactureName;
        public string ManufactureID;
        public string DevType;
        public string DevID;
        public string DevName;
    }

    public class S_UITransferItemInfo
    {
        public string serialNum { get; set; }
        public string paramName { get; set; }
        public E_UITransferParamType paramType { get; set; }
        public E_UITransferItemType itemType { get; set; }
        public string unit { get; set; }
        public E_UITransferPriorityType rwPriority { get; set; }
        public string VIEW1 { get; set; }
        public string VIEW2 { get; set; }
        public string VIEW3 { get; set; }
        public string VIEW4_1 { get; set; }
        public string VIEW4_2 { get; set; }
        public string VIEW4_3 { get; set; }
        public string VIEW4_4 { get; set; }
        public string helpInfo { get; set; }
    }

    public class S_UIFuncItemInfo
    {
        public string serialNum { get; set; }
        public string ChannelNum { get; set; }
        public E_UIFunctionParamType cyclePara { get; set; }
        public string rangeConfigTop { get; set; }
        public string rangeConfigEnd { get; set; }
        public string unit { get; set; }
    }


}
