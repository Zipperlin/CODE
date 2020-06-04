﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using InstrumentOperation.Common;
using System.Windows.Input;
using InstrumentOperation.Model;

namespace InstrumentOperation.ViewModel
{
    class FFViewModel : Singleton<FFViewModel>, INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _manuInfo;
        public string ManuInfo
        {
            get
            {
                return _manuInfo;
            }
            set
            {
                _manuInfo = value;
                OnPropertyChanged();
            }
        }

        private string _manuID;
        public string ManuID
        {
            get
            {
                return _manuID;
            }
            set
            {
                _manuID = value;
                OnPropertyChanged();
            }
        }

        private string _deviceType;
        public string DeviceType
        {
            get
            {
                return _deviceType;
            }
            set
            {
                _deviceType = value;
                OnPropertyChanged();
            }
        }

        private string _deviceName;
        public string DeviceName
        {
            get
            {
                return _deviceName;
            }
            set
            {
                _deviceName = value;
                OnPropertyChanged();
            }
        }

        private string _deviceSerial;
        public string DeviceSerial
        {
            get
            {
                return _deviceSerial;
            }
            set
            {
                _deviceSerial = value;
                OnPropertyChanged();
            }
        }

        private string _version;
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        private FFLogicModel ffLogicModel = new FFLogicModel();

        /// <summary>
        /// 确认工程类型
        /// </summary> 
        public ICommand Command_GenerateFFFile => new DelegateCommand(obj =>
        {
            ffLogicModel.FFGenerateCode();
        });
        #endregion
    }
}
