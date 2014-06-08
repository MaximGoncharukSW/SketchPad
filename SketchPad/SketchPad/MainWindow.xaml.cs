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
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            InitializeComponent( );

            AccountsGrid accGrid = new AccountsGrid( );
            Accounts.Content = accGrid;
            this.Closing += accGrid.Close;
            this.SizeChanged += accGrid.UpdateWeather;
           

            Schedule.Content = new ScheduleGrid( );

            Weather wf = new Weather( );
            wf.UpdateWeather( );

        }

        private void tabControl_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            this.Title = ( ( TabItem )( ( TabControl )sender ).SelectedItem ).Header.ToString();
        }
    }
}
