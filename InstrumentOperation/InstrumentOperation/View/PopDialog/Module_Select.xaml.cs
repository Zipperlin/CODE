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
using System.Windows.Shapes;
using InstrumentOperation.ViewModel;
using MahApps.Metro.Controls;

namespace InstrumentOperation.View.PopDialog
{
    /// <summary>
    /// Module_Select.xaml 的交互逻辑
    /// </summary>
    public partial class Module_Select : MetroWindow
    {
        public Module_Select()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = ModuleViewModel.GetInstance();
        }
    }
}
