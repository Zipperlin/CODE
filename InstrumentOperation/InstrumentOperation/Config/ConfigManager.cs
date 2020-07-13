﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentOperation.Common;
using InstrumentOperation.Config;
using System.Collections.ObjectModel;

namespace InstrumentOperation.FileManager
{
    public class ConfigManager:Singleton<ConfigManager>
    {
        private ConfigUIFile m_file=new ConfigUIFile();
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ReadConfigFile()
        {
            //m_file.GetConfigData("../../../settingconfig.xml");
            return false;
        }

        public bool GetConfigInfo(S_ConfigInfo configInfo)
        {
            configInfo.ConfigPattern = new Dictionary<E_Pattern, string>();
            configInfo.ConfigPattern.Add(E_Pattern.e_Pattern_ManufactureName,"");

            return false;
        }

        public S_ConfigUIInfo GetConfigUIInfo()
        {
            return m_file.GetConfigUIInfo();
        }

        public void GetInitInfo()
        {
            m_file.GetInitInfo();
        }

        public ObservableCollection<S_UITransferItemInfo> GetTransferInitInfo()
        {
            return m_file.GetTransferInitInfo();
        }

        public ObservableCollection<string> GetParamTypeList()
        {
            return m_file.GetParamTypeList();
        }
    }
}
