using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Common
{ 
    public enum E_Module
    {
        e_FF_Module,
        e_HART_Module,
        e_PA_Module,
    }

    public struct S_ManufactureInfo
    {
        public string ManufactureName;
        public string ManufactureID;
        public string DevType;
        public string DevID;
        public string DevName;
    }

    public enum E_Pattern
    {
        e_Pattern_ManufactureName,
    }

    public struct S_ConfigInfo
    {
        public Dictionary<E_Pattern, string> ConfigPattern;
    }

    public enum E_FileType
    {
        e_FF_File,
        e_HART_File,
        e_PA_File,
    }

    public struct S_ConfigUIInfo
    {
        public ObservableCollection<ItemTreeData> treeData;
    }

    public class S_CommucationItemInfo
    {
        public string imageName { get; set; }
        public string imagePath { get; set; }
    }

    public class S_TransferItemInfo
    {
        public string serialNum { get; set; }
        public string paramName { get; set; }
        public string paramType { get; set; }
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

    public enum E_Component
    {
        e_CPU,
        e_1,
        e_2,
    }

}
