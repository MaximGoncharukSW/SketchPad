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

            HideScriptErrors( browser, true );
        }

        private void btnSearch_Click( object sender, RoutedEventArgs e )
        {
            string transport = ( rbtnSuburban.IsChecked == true ) ? "suburban" : "train";
            string when = ( rbtnNow.IsChecked == true ) ? "" : "на+всi+днi";
            string url = String.Format( "http://rasp.yandex.ua/search/{0}/?toName={1}&fromName={2}&when={3}", transport, txtToName.Text, txtFromName.Text, when  );

            browser.Source = new Uri( url );
        }

        public void HideScriptErrors( WebBrowser wb, bool hide )
        {
            var fiComWebBrowser = typeof( WebBrowser ).GetField( "_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic );
            if( fiComWebBrowser == null )
                return;
            var objComWebBrowser = fiComWebBrowser.GetValue( wb );
            if( objComWebBrowser == null )
            {
                wb.Loaded += ( o, s ) => HideScriptErrors( wb, hide ); //In case we are to early
                return;
            }
            objComWebBrowser.GetType( ).InvokeMember( "Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[ ] { hide } );
        }

        private void browser_Navigated( object sender, NavigationEventArgs e )
        {
            browser.Focus( );
        }
    }
}
