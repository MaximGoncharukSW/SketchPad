using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WeatherControl
{
    /// <summary>
    /// Interaction logic for WeatherGrid.xaml
    /// </summary>
    public partial class WeatherGrid : UserControl
    {
        private Weather currentWeather;
        private DispatcherTimer dispatcherTimer;
        private event EventHandler WeatherUpdated;

        public WeatherGrid( )
        {
            InitializeComponent( );
            currentWeather = new Weather( );
            WeatherUpdated += WeatherGrid_WeatherUpdated;

            UpdateWeather( null, new EventArgs( ) );

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer( );
            dispatcherTimer.Tick += new EventHandler( UpdateWeather );
            dispatcherTimer.Interval = new TimeSpan( 0, 30, 0 );
            dispatcherTimer.Start( );
        }

        private void UpdateWeather( object sender, EventArgs e )
        {
            currentWeather.UpdateWeather( );
            WeatherUpdated( null, new EventArgs( ) );
        }

        private void WeatherGrid_WeatherUpdated( object sender, EventArgs e )
        {
            tbTodayNight.Text = currentWeather.Conditions[ 0 ].NightTemperature;
            tbTodayMorn.Text = currentWeather.Conditions[ 0 ].MorningTemperature;
            tbTodayDay.Text = currentWeather.Conditions[ 0 ].DayTemperature;
            tbTodayEve.Text = currentWeather.Conditions[ 0 ].EveningTemperature;
            tbTodayCloudy.Text = currentWeather.Conditions[ 0 ].Cloudy;
            tbTodayWindy.Text = currentWeather.Conditions[ 0 ].WindSpeed + "м/с";

            tbTomorrowNight.Text = currentWeather.Conditions[ 1 ].NightTemperature;
            tbTomorrowMorn.Text = currentWeather.Conditions[ 1 ].MorningTemperature;
            tbTomorrowDay.Text = currentWeather.Conditions[ 1 ].DayTemperature;
            tbTomorrowEve.Text = currentWeather.Conditions[ 1 ].EveningTemperature;
            tbTomorrowCloudy.Text = currentWeather.Conditions[ 1 ].Cloudy;
            tbTomorrowWindy.Text = currentWeather.Conditions[ 1 ].WindSpeed + "м/с";

            tbAfterTomorrowNight.Text = currentWeather.Conditions[ 2 ].NightTemperature;
            tbAfterTomorrowMorn.Text = currentWeather.Conditions[ 2 ].MorningTemperature;
            tbAfterTomorrowDay.Text = currentWeather.Conditions[ 2 ].DayTemperature;
            tbAfterTomorrowEve.Text = currentWeather.Conditions[ 2 ].EveningTemperature;
            tbAfterTomorrowCloudy.Text = currentWeather.Conditions[ 2 ].Cloudy;
            tbAfterTomorrowWindy.Text = currentWeather.Conditions[ 2 ].WindSpeed + "м/с";
        }
    }
}
