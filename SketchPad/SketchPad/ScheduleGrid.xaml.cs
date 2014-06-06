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

namespace SketchPad
{
    /// <summary>
    /// Interaction logic for ScheduleGrid.xaml
    /// </summary>
    public partial class ScheduleGrid : UserControl
    {
        public ScheduleGrid( )
        {
            InitializeComponent( );
            browser.Navigated += BrowserManager.Navigated;
            BrowserManager.HideScriptErrors( browser, true );
        }

        private void btnSearch_Click( object sender, RoutedEventArgs e )
        {
            BrowserManager.Search( browser, rbtnSuburban.IsChecked, rbtnNow.IsChecked, txtToName.Text, txtFromName.Text );
        }

        private void btnClear_Click( object sender, RoutedEventArgs e )
        {
            txtFromName.Text = "";
            txtToName.Text = "";
            rbtnNow.IsChecked = true;
            rbtnSuburban.IsChecked = true;
            browser.Source = null;
        }
    }
}