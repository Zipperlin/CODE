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


}
