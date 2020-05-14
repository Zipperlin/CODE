﻿using System;
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

namespace InstrumentOperation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow :MetroWindow
    {
        private HomeViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new HomeViewModel();
            frame.Source= new Uri("pack://application:,,,/View/FF/FF.xaml", UriKind.Absolute);
            DataContext = _viewModel;
        }      
    }
}
