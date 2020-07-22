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

namespace InstrumentOperation.UI.PA
{
    /// <summary>
    /// PA.xaml 的交互逻辑
    /// </summary>
    public partial class PA : Page
    {
        public PA()
        {
            InitializeComponent();
            DataContext = FFViewModel.GetInstance();
            FFViewModel.GetInstance().InitFFStatus();
        }

        private void Frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext();
        }

        private void Frame_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateFrameDataContext();
        }

        private void UpdateFrameDataContext()
        {
        }
    }
}
