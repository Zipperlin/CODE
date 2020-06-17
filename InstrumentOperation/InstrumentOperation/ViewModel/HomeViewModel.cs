using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstrumentOperation.Common;
using System.Windows.Input;
using InstrumentOperation.View.PopDialog;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using InstrumentOperation.Model;
using InstrumentOperation.View.Common;

namespace InstrumentOperation.ViewModel
{
    class HomeViewModel :Singleton<HomeViewModel>,INotifyPropertyChanged
    {

        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
       
      
        #region 数据
        /// <summary>
        /// 页面源
        /// </summary> 
        private Uri _data_PageSource;
        public Uri Data_PageSource
        {
            get { return _data_PageSource; }
            set
            {
                _data_PageSource = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 模块页面
        /// </summary> 
        private Module_Select _moduleSelect;
        public Module_Select ModuleSelect
        {
            get
            {
                if (_moduleSelect == null)
                {
                    _moduleSelect = new Module_Select();
                }
                return _moduleSelect;
            }
            set
            {
                _moduleSelect = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ItemTreeData> _itemTreeDataList;
        public ObservableCollection<ItemTreeData> ItemTreeDataList
        {
            get
            {
                if (_itemTreeDataList == null)
                {
                    _itemTreeDataList = new ObservableCollection<ItemTreeData>();
                }
                return _itemTreeDataList;
            }
            set
            {
                _itemTreeDataList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<S_CommucationItemInfo> _communicationModuleList;
        public ObservableCollection<S_CommucationItemInfo> CommunicationModuleList
        {
            get
            {
                if (_communicationModuleList == null)
                {
                    _communicationModuleList = new ObservableCollection<S_CommucationItemInfo>();
                }
                return _communicationModuleList;
            }
            set
            {
                _communicationModuleList = value;
                OnPropertyChanged();
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        private E_Component _eComponent;
        public E_Component EComponent
        {
            get
            {
                return _eComponent;
            }
            set
            {
                _eComponent = value;
                OnPropertyChanged();
            }
        }


        private ConfigLogicModel configModel;

        #endregion

        #region 定义命令 

        /// <summary>
        /// 创建新工程
        /// </summary> 
        public ICommand Command_CreateNewFile => new DelegateCommand(obj =>
        {
            ModuleSelect.Show();
        });

        /// <summary>
        /// 生成文件
        /// </summary> 
        public ICommand Command_Generate => new DelegateCommand(obj =>
        {
            
        });

        /// <summary>
        /// 保存文件
        /// </summary> 
        public ICommand Command_SaveFile => new DelegateCommand(obj =>
        {

        });

        /// <summary>
        /// 关闭文件
        /// </summary> 
        public ICommand Command_CloseFile => new DelegateCommand(obj =>
        {

        });

        public ICommand Command_FillConfigInfo
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if(CommunicationModuleList.Count>0)
                    {
                        S_CommucationItemInfo itemInfo = (S_CommucationItemInfo)obj;
                        String itemName = itemInfo.imageName;

                        ConfigInfoDialog dialog = new ConfigInfoDialog();
                       
                        switch (itemName)
                        {
                            case "FF":
                                {
                                    //FFViewModel.GetInstance().TransferItemsList.Add();
                                    ChangeModule(E_Module.e_FF_Module);

                                }
                                break;
                            case "HART":
                                {
                                    ChangeModule(E_Module.e_HART_Module);
                                }
                                break;
                            case "PA":
                                {
                                    ChangeModule(E_Module.e_PA_Module);
                                }
                                break;
                            default:
                                break;
                        }

                        dialog.ShowDialog();
                    }
                   
                });
            }
        }


        public ICommand Command_DoubleClickTreeItem
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ItemTreeData item = (ItemTreeData)obj;
                    String sName= item.itemName;

                    switch (sName)
                    {
                        case "FF":
                            {
                                S_CommucationItemInfo sinfo = new S_CommucationItemInfo();
                                sinfo.imageName = "FF";
                                sinfo.imagePath = @"D:\项目文件\仪表操作系统\图片素材\设备图片\板卡\IMG_1413_edit.png";
                                CommunicationModuleList.Add(sinfo);
                            }
                            break;
                        case "HART":
                            {
                                S_CommucationItemInfo sinfo = new S_CommucationItemInfo();
                                sinfo.imageName = "HART";
                                sinfo.imagePath = @"D:\项目文件\仪表操作系统\图片素材\设备图片\板卡\hart圆卡.jpg";
                                CommunicationModuleList.Add(sinfo);
                            }
                            break;
                        case "PA":
                            {
                                S_CommucationItemInfo sinfo = new S_CommucationItemInfo();
                                sinfo.imageName = "PA";
                                sinfo.imagePath = @"D:\项目文件\仪表操作系统\图片素材\设备图片\板卡\IMG_20150720_085646.jpg";
                                CommunicationModuleList.Add(sinfo);
                            }
                            break;
                        default:
                            break;
                    }
                });
            }
        }

        public ICommand Command_RightClickTreeItem => new DelegateCommand(obj =>
        {
            if (CommunicationModuleList.Count > 0)
            {
                CommunicationModuleList.RemoveAt(CommunicationModuleList.Count-1);
            }
            
        });

        #endregion

        #region 定义方法
        public void ChangeModule(E_Module moduleType)
        {
            switch (moduleType)
            {
                case E_Module.e_FF_Module:
                    Data_PageSource = new Uri("pack://application:,,,/View/FF/FF.xaml", UriKind.Absolute);
                    break;
                case E_Module.e_HART_Module:
                    Data_PageSource = new Uri("pack://application:,,,/View/HART/HART.xaml", UriKind.Absolute);
                    break;
                case E_Module.e_PA_Module:
                    Data_PageSource = new Uri("pack://application:,,,/View/PA/PA.xaml", UriKind.Absolute);
                    break;
                default:
                    break;
            }

            if (ModuleSelect != null)
            {
                //To do:此处释放资源存在问题
                ModuleSelect.Close();
                ModuleSelect = null;
            }
        }

        public void InitTreeView()
        {
            configModel = new ConfigLogicModel();
            this.ItemTreeDataList = configModel.GetConfigUIInfo().treeData;

            
        }

        public void GetConfig()
        {
            configModel = new ConfigLogicModel();
            configModel.GetConfigInfo();     
        }

        #endregion

        #region 事件处理
        void On_ModuleChanged_Receiver(E_Module message)
        {
            //TO DO:目前这里动态加载有问题，无法动态切换
            switch(message)
            {
                case E_Module.e_FF_Module:
                    Data_PageSource = new Uri("pack://application:,,,/View/FF/FF.xaml", UriKind.Absolute);
                    break;
                case E_Module.e_HART_Module:
                    Data_PageSource = new Uri("pack://application:,,,/View/HART/HART.xaml", UriKind.Absolute);
                    break;
                case E_Module.e_PA_Module:
                    Data_PageSource = new Uri("pack://application:,,,/View/PA/PA.xaml", UriKind.Absolute);
                    break;
                default:
                    break;
            }

            if(ModuleSelect!=null)
            {
                //To do:此处释放资源存在问题
                ModuleSelect.Close();
            }
            
        }
        
        #endregion

    }


}
