﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using InstrumentOperation.Common;
using System.Windows.Input;
using InstrumentOperation.Model;
using System.Collections.ObjectModel;
using InstrumentOperation.View.FF;
using System.Windows.Controls;

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

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _transferItemsList;
        public ObservableCollection<string> TransferItemsList
        {
            get
            {
                if (_transferItemsList == null)
                {
                    _transferItemsList = new ObservableCollection<string>();
                    _transferItemsList.Add("转换块1");
                }
                return _transferItemsList;
            }
            set
            {
                _transferItemsList = value;
                OnPropertyChanged();
            }
        }

        private FFLogicModel ffLogicModel;

        /// <summary>
        /// 确认工程类型
        /// </summary> 
        public ICommand Command_GenerateFFFile => new DelegateCommand(obj =>
        {
            ffLogicModel = new FFLogicModel("D:\\项目文件\\仪表操作系统\\仪表操作系统项目\\DEMO_M0313\\DEMO\\Src\\UserApp.c");
            S_ManufactureInfo info = new S_ManufactureInfo();
            info.ManufactureName = ManuInfo;
            info.ManufactureID = ManuID;
            info.DevID = DeviceSerial;
            info.DevName = DeviceName;
            info.DevType = DeviceType;

            ffLogicModel.FFGenerateBasicCode(info);
        });

        public ICommand Command_AddTransferModule => new DelegateCommand(obj =>
        {
            int icount = TransferItemsList.Count();
            icount++;
            string sNum=icount.ToString();
            TransferItemsList.Add("转换块"+sNum);
        });
        #endregion
    }
}
