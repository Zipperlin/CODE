using System;
using System.Collections.Generic;
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
        string ManufactureName;
        string ManufactureID;
        string DevType;
        string DevID;
        string DevName;
    }

    public enum E_Pattern
    {
        e_Pattern_ManufactureName,
    }

    public struct S_ConfigInfo
    {
        public Dictionary<E_Pattern, string> ConfigPattern;
    }
}
