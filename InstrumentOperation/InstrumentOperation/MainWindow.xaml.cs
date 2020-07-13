using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InstrumentOperation.ViewModel;
using MahApps.Metro.Controls;
using HandyControl;
using System.Xml;
using System.Windows.Markup;
using InstrumentOperation.Common;

namespace InstrumentOperation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = HomeViewModel.GetInstance();

            HomeViewModel.GetInstance().InitTreeView();
            HomeViewModel.GetInstance().GetConfig();

            //初始化log类
            Logger.InitLogger();


            //int i = 0;
            //while(i<1000)
            //{
            //    Logger.Logger_Info("软件启动info");
            //    Logger.Logger_Error("软件启动error");
            //    Logger.Logger_Warn("软件启动warn");
            //    i++;
            //}


            // test code
            // log4net.Config.XmlConfigurator.Configure();
            // log4net.ILog log = log4net.LogManager.GetLogger("Instrument.Logging");//获取一个日志记录器
            // log.Info(DateTime.Now.ToString() + ": login success");//写入一条新log
        }

    }
}
