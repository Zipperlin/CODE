using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstrumentOperation.Common;
using System.Windows.Input;
using System.ComponentModel;

namespace InstrumentOperation.ViewModel
{
    public class ModuleViewModel: Singleton<ModuleViewModel>, INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 工程类型
        /// </summary> 
        private E_Module _data_ModuleType;
        public E_Module Data_ModuleType
        {
            get { return _data_ModuleType; }
            set
            {
                _data_ModuleType = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region 定义命令
        /// <summary>
        /// 确认工程类型
        /// </summary> 
        public ICommand Command_ConfirmModuleType => new DelegateCommand(obj =>
        {
            HomeViewModel.GetInstance().ChangeModule(Data_ModuleType);          
        });

        /// <summary>
        /// 取消选择工程类型
        /// </summary> 
        public ICommand Command_CancelModuleType => new DelegateCommand(obj =>
        {
            
        });

        /// <summary>
        /// 定义委托
        /// </summary>
        public delegate void del_Module_Changed(E_Module msg);

        /// <summary>
        /// 定义事件
        /// </summary>
        public event del_Module_Changed Event_ChangeModule;

        #endregion
    }
}
