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

        public ObservableCollection<S_TransferItemInfo> GetTransferInitInfo()
        {
            return configManager.GetTransferInitInfo();
        }
    }
}
