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
        USIGN16,
        USIGN8,
        FLOAT,
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

    public struct S_UITransferFilePath
    {
        public string XTBhPath;
        public string XTBCPath;
        public string XTBdPath;
    }

    public struct S_UIFunctionFilePath
    {
        public string UserAppPath;
        public string FFSeriesDllPath;
        public string FFSeriesPath;
        public string FFSeriesTBDllPath;
    }

    public class S_CommucationItemInfo
    {
        public string imageName { get; set; }
        public string imagePath { get; set; }
    }  

    public class S_TransferTabList
    {
        public S_UITransferFilePath sFilePath;
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
        public string itemType { get; set; }
        public string unit { get; set; }
        public string rwPriority { get; set; }
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
