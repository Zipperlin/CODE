using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Common
{
    public class ConfigManager:Singleton<ConfigManager>
    {

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool ReadConfigFile(string filePath)
        {
            return false;
        }

        bool GetConfigInfo(S_ConfigInfo configInfo)
        {
            configInfo.ConfigPattern = new Dictionary<E_Pattern, string>();
            configInfo.ConfigPattern.Add(E_Pattern.e_Pattern_ManufactureName,"");

            return false;
        }
    }
}
