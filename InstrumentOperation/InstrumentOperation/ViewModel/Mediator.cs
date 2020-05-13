using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentOperation.Common;

namespace InstrumentOperation.ViewModel
{
    public class Mediator
    {
        #region 数据
        private static Mediator instance;
        private static object _lock = new object();

        /// <summary>
        /// 定义委托
        /// </summary>
        public delegate void del_Module_Changed(E_Module msg);

        /// <summary>
        /// 定义事件
        /// </summary>
        public event del_Module_Changed Event_ChangeModule;

        #endregion

        private Mediator()
        {

        }

        public static Mediator GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Mediator();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage_ModuleTypeChanged(E_Module message)
        {
            Event_ChangeModule(message);
        }
    }
}
