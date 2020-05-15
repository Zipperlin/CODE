using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstrumentOperation.Common;
using System.Windows.Input;
using InstrumentOperation.View.PopDialog;
using System.Windows.Controls;
using System.ComponentModel;

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
                ModuleSelect = value;
                OnPropertyChanged();
            }
        }

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
            }
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
