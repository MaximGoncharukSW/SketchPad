using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
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

        private void tabControl_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            this.Title = ( ( TabItem )( ( TabControl )sender ).SelectedItem ).Header.ToString();
        }
    }
}
