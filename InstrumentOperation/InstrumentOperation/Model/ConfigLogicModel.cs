using InstrumentOperation.Common;
using InstrumentOperation.FileManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Model
{
    public class ConfigLogicModel
    {
        private ConfigManager configManager = new ConfigManager();
        public void GetConfigInfo()
        {
            configManager.ReadConfigFile();
        }

        public S_ConfigUIInfo GetConfigUIInfo()
        {
            return configManager.GetConfigUIInfo();
        }

        public void GetInitInfo()
        {
            configManager.GetInitInfo();
        }

        public ObservableCollection<S_UITransferItemInfo> GetTransferInitInfo()
        {
            return configManager.GetTransferInitInfo();
        }

        public ObservableCollection<string> GetTransferInitValue()
        {
            return configManager.GetParamTypeList();
        }
    }
}
