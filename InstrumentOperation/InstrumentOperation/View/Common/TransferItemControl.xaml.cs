using InstrumentOperation.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InstrumentOperation.View.Common
{
    /// <summary>
    /// TransferItemControl.xaml 的交互逻辑
    /// </summary>
    public partial class TransferItemControl : UserControl
    {
        public TransferItemControl()
        {
            InitializeComponent();
        }

        public  ObservableCollection<S_TransferItemInfo> TransferInfoList
        {
           
            get { return (ObservableCollection<S_TransferItemInfo>)GetValue(TransferInfoListProperty); }
            set { SetValue(TransferInfoListProperty, value); }         
        }

        public static readonly DependencyProperty TransferInfoListProperty =
        DependencyProperty.Register("TransferInfoList", typeof(ObservableCollection<S_TransferItemInfo>), typeof(TransferItemControl), new PropertyMetadata(null, (s, e) =>
        {
            ((TransferItemControl)s).TransferInfoList = (ObservableCollection<S_TransferItemInfo>)e.NewValue;
        }));
    }
}
