using InstrumentOperation.ViewModel;
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

namespace InstrumentOperation.UI.FF
{
    /// <summary>
    /// FF.xaml 的交互逻辑
    /// </summary>
    public partial class FF : Page
    {
        public FF()
        {
            InitializeComponent();
            DataContext = FFViewModel.GetInstance();

        }

        private void Frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext();
        }

        private void Frame_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateFrameDataContext();
        }

        /// <summary>
        ///  Frame 的 DataContext 不能被 Page 继承,需要做进一步的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateFrameDataContext()
        {
            var content = this.Frame_Transfer.Content as FrameworkElement;
            if (content == null)
            {
                return;
            }
            content.DataContext = this.Frame_Transfer.DataContext;
        }
    }
}
