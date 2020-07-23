using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using InstrumentOperation.Common;
using System.Windows.Input;
using InstrumentOperation.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using InstrumentOperation.View.Common;
using System.Windows.Data;
using HandyControl.Data;
using InstrumentOperation.Converter;
using System.Diagnostics;
using InstrumentOperation.View.PopDialog;
using System.Threading;

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

        private string _solutionPath;
        public string SolutionPath
        {
            get
            {
                return _solutionPath;
            }
            set
            {
                _solutionPath = value;               
                OnPropertyChanged();
            }
        }

        private string _ddsolutionPath;
        public string DDSolutionPath
        {
            get
            {
                return _ddsolutionPath;
            }
            set
            {
                _ddsolutionPath = value;
                OnPropertyChanged();
            }
        }

        private string DDNewSolutionPath;
        private string NewSolutionPath;

        private bool _bSetBackup;
        public bool bSetBackup
        {
            get
            {
                return _bSetBackup;
            }
            set
            {
                _bSetBackup = value;
                OnPropertyChanged();
            }
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

        private int _selectedItemIndex;
        public int SelectedItemIndex
        {
            get
            {
                return _selectedItemIndex;
            }
            set
            {
                _selectedItemIndex = value;
                OnPropertyChanged();
            }
        }

        private int _aiNum;
        public int AINum
        {
            get
            {
                return _aiNum;
            }
            set
            {
                _aiNum = value;
                OnPropertyChanged();
            }
        }

        private int _aoNum;
        public int AONum
        {
            get
            {
                return _aoNum;
            }
            set
            {
                _aoNum = value;
                OnPropertyChanged();
            }
        }

        private int _dINum;
        public int DINum
        {
            get
            {
                return _dINum;
            }
            set
            {
                _dINum = value;
                OnPropertyChanged();
            }
        }

        private int _dONum;
        public int DONum
        {
            get
            {
                return _dONum;
            }
            set
            {
                _dONum = value;
                OnPropertyChanged();
            }
        }

        private int _pIDNum;
        public int PIDNum
        {
            get
            {
                return _pIDNum;
            }
            set
            {
                _pIDNum = value;
                OnPropertyChanged();
            }
        }

        private int _rANum;
        public int RANum
        {
            get
            {
                return _rANum;
            }
            set
            {
                _rANum = value;
                OnPropertyChanged();
            }
        }

        private int _iSNum;
        public int ISNum
        {
            get
            {
                return _iSNum;
            }
            set
            {
                _iSNum = value;
                OnPropertyChanged();
            }
        }

        private int _sCNum;
        public int SCNum
        {
            get
            {
                return _sCNum;
            }
            set
            {
                _sCNum = value;
                OnPropertyChanged();
            }
        }

        private int _llCNum;
        public int LLNum
        {
            get
            {
                return _llCNum;
            }
            set
            {
                _llCNum = value;
                OnPropertyChanged();
            }
        }

        private int _bGNum;
        public int BGNum
        {
            get
            {
                return _bGNum;
            }
            set
            {
                _bGNum = value;
                OnPropertyChanged();
            }
        }

        private string _transferName;
        public string TransferName
        {
            get
            {
                return _transferName;
            }
            set
            {
                _transferName = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<string> _transferParamTypeList;
        public ObservableCollection<string> TransferParamTypeList
        {
            get
            {
                if (_transferParamTypeList == null)
                {
                    _transferParamTypeList = new ObservableCollection<string>();

                }
                return _transferParamTypeList;
            }
            set
            {
                _transferParamTypeList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _transferItemTypeList;
        public ObservableCollection<string> TransferItemTypeList
        {
            get
            {
                if (_transferItemTypeList == null)
                {
                    _transferItemTypeList = new ObservableCollection<string>();

                }
                return _transferItemTypeList;
            }
            set
            {
                _transferItemTypeList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<S_TransferTabList> _transferList;
        public ObservableCollection<S_TransferTabList> TransferList
        {
            get
            {
                if (_transferList == null)
                {
                    _transferList = new ObservableCollection<S_TransferTabList>();
                }
                return _transferList;
            }
            set
            {
                _transferList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<S_UIFuncItemInfo> _funcItemList;
        public ObservableCollection<S_UIFuncItemInfo> FuncItemList
        {
            get
            {
                if (_funcItemList == null)
                {
                    _funcItemList = new ObservableCollection<S_UIFuncItemInfo>();

                }
                return _funcItemList;
            }
            set
            {
                _funcItemList = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<CoverViewDemoModel> _coverViewataList;
        public ObservableCollection<CoverViewDemoModel> CoverViewataList
        {
            get
            {
                if (_coverViewataList == null)
                {
                    _coverViewataList = new ObservableCollection<CoverViewDemoModel>();
                }
                return _coverViewataList;
            }
            set
            {
                _coverViewataList = value;
                OnPropertyChanged();
            }
        }

        private FFLogicModel ffLogicModel;
        private ConfigLogicModel configModel;

        public ICommand Command_OpenFFFolder => new DelegateCommand(obj =>
        {
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments =NewSolutionPath;
            p.Start();
        }); 

        public ICommand Command_ReplaceFFInfo => new DelegateCommand(obj =>
        {
            GenerateCode();          
        }); 

        public void InitFFStatus()
        {
            bSetBackup = true;
            SolutionPath = "D:\\项目文件\\仪表操作系统\\仪表操作系统项目\\DEMO_M0313\\DEMO";
            DDSolutionPath = "D:\\项目文件\\仪表操作系统\\仪表操作系统项目\\DD_DEMO";
            TransferName = "XTB";

            Thread t = new Thread(BackupFiles);
            t.Start();

            ClearFFStatus();
            AddTransferModule();

            AONum = 1;
            DINum = 1;
            DONum = 1;
            PIDNum = 1;   
        }

        public void ClearFFStatus()
        {
            if(null!= TransferList)
            {
                TransferList.Clear();
            }

            if (null != FuncItemList)
            {
                FuncItemList.Clear();
            }
        }

        private void BackupFiles()
        {
            if (bSetBackup)
            {
                string sourcePath = SolutionPath;
                string targetPath = SolutionPath + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                NewSolutionPath = targetPath;

                string ddsourcePath = DDSolutionPath;
                string ddtargetPath = DDSolutionPath + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                DDNewSolutionPath = ddtargetPath;

                CommonFileOperator.DirectoryCopy(sourcePath, targetPath, true);
                CommonFileOperator.DirectoryCopy(ddsourcePath, ddtargetPath, true);
            }
        }

        public void GenerateCode()
        {
            //Generate Basic Code
            GenerateBasicCode();

            //Generate Transfer code
            GenerateTransferCode();

            //Genrate Function code
            GenerateFunctionCode();

            //Generate DD code
            GenerateDDCode();
        }

        private void GenerateBasicCode()
        {            
            string filePath= NewSolutionPath + "\\Src\\UserApp.c";
            ffLogicModel = new FFLogicModel();
            S_UIManufactureInfo info;
            info.ManufactureName = ManuInfo;
            info.ManufactureID = ManuID;
            info.DevID = DeviceSerial;
            info.DevName = DeviceName;
            info.DevType = DeviceType;
            ffLogicModel.FFGenerateBasicCode(filePath, info);
        }

        private static int TransferItemNum = 11;

        private void GenerateTransferCode()
        {
            string fileXTBHPath= NewSolutionPath + "\\Src\\X_TB.h";
            string fileXTBCPath= NewSolutionPath + "\\Src\\X_TBc.c";
            string NexfileXTBHPath="";
            string NewfileXTBCPath="";
            string NewfileXTBdPath = "";
            ffLogicModel = new FFLogicModel();
            
            for(int i=0;i< TransferList.Count;i++)
            {
                NexfileXTBHPath = NewSolutionPath + "\\Src\\" + TransferList[i].tabHeader+ ".h" ;
                NewfileXTBCPath = NewSolutionPath + "\\Src\\" + TransferList[i].tabHeader + ".c";

                CommonFileOperator.copyFile(fileXTBHPath, NexfileXTBHPath, true);
                CommonFileOperator.copyFile(fileXTBCPath, NewfileXTBCPath, true);

                TransferList[i].sFilePath.TransferName = TransferName;
                TransferList[i].sFilePath.XTBCPath = NewfileXTBCPath;
                TransferList[i].sFilePath.XTBhPath = NexfileXTBHPath;
                TransferList[i].sFilePath.XTBdPath = NewfileXTBdPath;
            }

            foreach (S_TransferTabList var in TransferList)
            {
                int i = 0;
                foreach(S_UITransferItemInfo item in var.tabContent)
                {
                    if(i> TransferItemNum)
                    {
                        ffLogicModel.FFGenerateTransferCode(var.sFilePath, item);
                    }
                    i++;
                }      
            }    
        }

        private void GenerateFunctionCode()
        {
            ffLogicModel = new FFLogicModel();

            S_UIFuncFileProperties uiFileProperties=new S_UIFuncFileProperties();
            uiFileProperties.UserAppPath = NewSolutionPath + "\\Src\\UserApp.h";

            uiFileProperties.AINum = AINum;
            uiFileProperties.AONum = AONum;
            uiFileProperties.RANum = RANum;
            uiFileProperties.DINum = DINum;
            uiFileProperties.DONum = DONum;
            uiFileProperties.PIDNum = PIDNum;
            uiFileProperties.SCNum = SCNum;
            uiFileProperties.ISNum = ISNum;
            uiFileProperties.LLNum = LLNum;
            uiFileProperties.BGNum = BGNum;

            for (int i = 0; i < FuncItemList.Count; i++)
            {
                ffLogicModel.FFGenerateFuncCode(uiFileProperties, FuncItemList[i]);
            }
        }

        private void GenerateDDCode()
        {
            ffLogicModel = new FFLogicModel();
            S_UIDDFileProperties uiFileProperties = new S_UIDDFileProperties();
            uiFileProperties.FFSeriesDDlPath = DDNewSolutionPath + "\\M0313"+ "\\M0313_FF_Series.ddl";
            uiFileProperties.FFSeriesPath = DDNewSolutionPath + "\\M0313" + "\\M0313_FF_Series.h";
            uiFileProperties.FFSeriesTBDllPath = DDNewSolutionPath + "\\M0313" + "\\M0313_FF_Series_X_TB.ddl";

            uiFileProperties.funcProperties.AINum = AINum;
            uiFileProperties.funcProperties.AONum = AONum;
            uiFileProperties.funcProperties.DINum = DINum;
            uiFileProperties.funcProperties.DONum = DONum;
            uiFileProperties.funcProperties.RANum = RANum;
            uiFileProperties.funcProperties.BGNum = BGNum;
            uiFileProperties.funcProperties.PIDNum = PIDNum;
            uiFileProperties.funcProperties.LLNum = LLNum;
            uiFileProperties.funcProperties.SCNum = SCNum;
            uiFileProperties.funcProperties.ISNum = ISNum;

            uiFileProperties.basicPropertis.ManufactureName=ManuInfo;
            uiFileProperties.basicPropertis.ManufactureID = ManuID;
            uiFileProperties.basicPropertis.DevID = DeviceSerial;
            uiFileProperties.basicPropertis.DevName = DeviceName;
            uiFileProperties.basicPropertis.DevType = DeviceType;


            ffLogicModel.FFGenerateDDCode(uiFileProperties);
        }


        TransferPropertiesDialog transferPropertiesDialog;
        public ICommand Command_AddTransferModule => new DelegateCommand(obj =>
        {
            transferPropertiesDialog = new TransferPropertiesDialog();
            transferPropertiesDialog.Show();
            //AddTransferModule();
        });

        public ICommand Command_SetTransferName => new DelegateCommand(obj =>
        {
            AddTransferModule();

            if (null != transferPropertiesDialog)
            {
                transferPropertiesDialog.Close();
            }
        });

        public ICommand Command_CloseTransferPropertiesDialog => new DelegateCommand(obj =>
        {
            if(null!= transferPropertiesDialog)
            {
                transferPropertiesDialog.Close();
            }
        });

        private void AddTransferModule()
        {
            int icount = TransferList.Count();
            icount++;
            string sNum = icount.ToString();

            S_TransferTabList slist = new S_TransferTabList();
            //slist.tabHeader = "转换块" + sNum;
            slist.tabHeader = TransferName;
            slist.tabContent = new ObservableCollection<S_UITransferItemInfo>();

            configModel = new ConfigLogicModel();
            configModel.GetInitInfo();
            foreach (S_UITransferItemInfo var in configModel.GetTransferInitInfo())
            {
                slist.tabContent.Add(var);
            }

            foreach (string var in configModel.GetTransferInitValue())
            {
                TransferParamTypeList.Add(var);
            }

            TransferList.Add(slist);
        }

        private void AddFuncModule()
        {
            AddTemplateModule(AONum, E_UIFunctionParamType.e_AI);
            AddTemplateModule(DONum, E_UIFunctionParamType.e_DO);
            AddTemplateModule(DINum, E_UIFunctionParamType.e_DI);
            AddTemplateModule(PIDNum, E_UIFunctionParamType.e_PID);
            AddTemplateModule(RANum, E_UIFunctionParamType.e_RA);
            AddTemplateModule(ISNum, E_UIFunctionParamType.e_IS);
            AddTemplateModule(SCNum, E_UIFunctionParamType.e_SC);
            AddTemplateModule(LLNum, E_UIFunctionParamType.e_LL);
            AddTemplateModule(BGNum, E_UIFunctionParamType.e_BG);
        }

        private void AddTemplateModule(int nCount,E_UIFunctionParamType type)
        {
            for (int i = 0; i < nCount; i++)
            {
                S_UIFuncItemInfo info = new S_UIFuncItemInfo();
                info.serialNum = (FuncItemList.Count() + 1).ToString();
                switch (type)
                {
                    case E_UIFunctionParamType.e_AI:
                        info.cyclePara = E_UIFunctionParamType.e_AI;
                        info.ChannelNum = "AI_" + (i+1).ToString();
                        break;
                    case E_UIFunctionParamType.e_AO:
                        info.cyclePara = E_UIFunctionParamType.e_AO;
                        info.ChannelNum = "AO_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_DI:
                        info.cyclePara = E_UIFunctionParamType.e_DI;
                        info.ChannelNum = "DI_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_DO:
                        info.cyclePara = E_UIFunctionParamType.e_DO;
                        info.ChannelNum = "DO_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_PID:
                        info.cyclePara = E_UIFunctionParamType.e_PID;
                        info.ChannelNum = "PID_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_RA:
                        info.cyclePara = E_UIFunctionParamType.e_RA;
                        info.ChannelNum = "RA_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_IS:
                        info.cyclePara = E_UIFunctionParamType.e_IS;
                        info.ChannelNum = "IS_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_SC:
                        info.cyclePara = E_UIFunctionParamType.e_SC;
                        info.ChannelNum = "SC_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_LL:
                        info.cyclePara = E_UIFunctionParamType.e_LL;
                        info.ChannelNum = "LL_" + (i + 1).ToString();
                        break;
                    case E_UIFunctionParamType.e_BG:
                        info.cyclePara = E_UIFunctionParamType.e_BG;
                        info.ChannelNum = "BG_" + (i + 1).ToString();
                        break;
                    default:
                        break;
                }
                FuncItemList.Add(info);
            }   
        }

        public ICommand Command_RemoveTransferModule => new DelegateCommand(obj =>
        {
            if (TransferList.Count > 1)
            {
                TransferList.RemoveAt(TransferList.Count-1);
            }
        });

        public ICommand Command_AddFuncModule => new DelegateCommand(obj =>
        {
            FuncItemList.Clear();
            AddFuncModule();
        });

        public void InitFuncModule()
        {
            FuncItemList = new ObservableCollection<S_UIFuncItemInfo>();
            S_UIFuncItemInfo sinfo = new S_UIFuncItemInfo();

           // FuncItemList.Add();
        }
        #endregion
    }
}
