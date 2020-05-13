using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstrumentOperation.Common;
using System.Windows.Input;

namespace InstrumentOperation.ViewModel
{
    public class ModuleViewModel:ViewModelBase
    {
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
                OnPropertyChanged(nameof(_data_ModuleType));
            }
        }
        #endregion

        #region 定义命令
        /// <summary>
        /// 确认工程类型
        /// </summary> 
        public ICommand Command_ConfirmModuleType => new DelegateCommand(obj =>
        {
            Mediator.GetInstance().SendMessage_ModuleTypeChanged(Data_ModuleType);           
        });

        /// <summary>
        /// 取消选择工程类型
        /// </summary> 
        public ICommand Command_CancelModuleType => new DelegateCommand(obj =>
        {
            
        });

        #endregion
    }
}
