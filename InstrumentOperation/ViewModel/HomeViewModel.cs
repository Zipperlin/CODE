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
using GalaSoft.MvvmLight.Command;
using HandyControl.Data;

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

        private Uri _coverViewItemPage;
        public Uri coverViewItemPage
        {
            get { return _coverViewItemPage; }
            set
            {
                _coverViewItemPage = value;
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

      

        private ObservableCollection<CardModel> _communicationList;
        public ObservableCollection<CardModel> CommunicationList
        {
            get
            {
                if (_communicationList == null)
                {
                    _communicationList = new ObservableCollection<CardModel>();
                }
                return _communicationList;
            }
            set
            {
                _communicationList = value;
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

        public class CoverViewDemoModel
        {
            public string ImgPath { get; set; }

            public string BackgroundToken { get; set; }

            public Uri coverViewItemPage { get; set; }
        }


        internal ObservableCollection<CoverViewDemoModel> GetCoverViewDemoDataList()
        {
            return new ObservableCollection<CoverViewDemoModel>
            {
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\1.jpg",
                //    BackgroundToken = ResourceToken.SuccessBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\2.jpg",
                //    BackgroundToken = ResourceToken.PrimaryBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\3.jpg",
                //    BackgroundToken = ResourceToken.WarningBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\4.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\5.jpg",
                //    BackgroundToken = ResourceToken.SuccessBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\6.jpg",
                //    BackgroundToken = ResourceToken.PrimaryBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\7.jpg",
                //    BackgroundToken = ResourceToken.InfoBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\8.jpg",
                //    BackgroundToken = ResourceToken.WarningBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\9.jpg",
                //    BackgroundToken = ResourceToken.PrimaryBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"C:\Users\雷霆世纪\Documents\Visual Studio 2017\Projects\WpfApp3\WpfApp3\Resources\Img\Album\10.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                // new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\os.png",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\采集图片.png",
                //    coverViewItemPage=new Uri("pack://application:,,,/View/FF/FF.xaml", UriKind.Absolute),
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\存储.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\显示.png",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\诊断.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                // new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\采集图片.png",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\存储.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\显示.png",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\诊断.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                // new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\采集图片.png",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\存储.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},
                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\显示.png",
                //    BackgroundToken = ResourceToken.DangerBrush
                //},

                //new CoverViewDemoModel
                //{
                //    ImgPath = @"D:\Project\InstrumentOperation\InstrumentOperation\Resources\诊断.jpg",
                //    BackgroundToken = ResourceToken.DangerBrush
                //}

            };
        }

        private ObservableCollection<CoverViewDemoModel> _imagedatalist;
        public ObservableCollection<CoverViewDemoModel> ImageDataList
        {
            get
            {
                if (_imagedatalist == null)
                {
                    _imagedatalist = new ObservableCollection<CoverViewDemoModel>();

                }
                return _imagedatalist;
            }
            set
            {
                _imagedatalist = value;
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
                    String sName = item.itemName;

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
                CommunicationModuleList.RemoveAt(CommunicationModuleList.Count - 1);
            }
        });

        public ICommand Command_AddItem2Area => new DelegateCommand(obj =>
        {
            CoverViewDemoModel model = new CoverViewDemoModel();
            model.ImgPath = @"D:\项目文件\仪表操作系统\图片素材\设备图片\板卡\IMG_1413_edit.png";
            model.coverViewItemPage = new Uri("pack://application:,,,/View/FF/FF.xaml", UriKind.Absolute);
            ImageDataList.Add(model);
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

            //if (ModuleSelect != null)
            //{
            //    //To do:此处释放资源存在问题
            //    ModuleSelect.Close();
            //    ModuleSelect = null;
            //}
        }

        public void InitTreeView()
        {
            configModel = new ConfigLogicModel();
            this.ItemTreeDataList = configModel.GetConfigUIInfo().treeData;
           
            ImageDataList =GetCoverViewDemoDataList();

            //coverViewItemPage = new Uri("pack://application:,,,/View/FF/FF.xaml", UriKind.Absolute);
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
