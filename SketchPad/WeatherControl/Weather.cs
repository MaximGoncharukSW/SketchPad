using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Net;

namespace WeatherControl
{
    public class Conditions
    {
        public string Cloudy;

        public string MaxTemperature;

        public string MinTemperature;

        public string DayTemperature;

        public string NightTemperature;

        public string MorningTemperature;

        public string EveningTemperature;

        public string WindSpeed;

        public string Date;
    }

    public class Weather
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private List<Conditions> conditions;

        public List<Conditions> Conditions
        {
            get
            {
                return conditions;
            }
        }

        public Weather( )
        {
            name = "";
            conditions = new List<Conditions>( );
        }

        public List<Conditions> UpdateWeather( )
        {
            if( conditions.Count != 0 )
                conditions.Clear( );

            WebClient client = new WebClient( );
            client.Encoding = Encoding.UTF8;
            string response = client.DownloadString( "http://api.openweathermap.org/data/2.5/forecast/daily?type=json&q=Makeevka&units=metric&cnt=3&lang=ru" );
            JObject ob = JObject.Parse( response );

            name = ob[ "city" ][ "name" ].ToString( );
            conditions = new List<Conditions>( );

            int maxDays = ob[ "list" ].Count( );
            var weather = ob[ "list" ];
            for( int i = 0; i < maxDays; i++ )
            {
                conditions.Add( new Conditions( )
                {
                    MaxTemperature = weather[ i ][ "temp" ][ "max" ].ToString( ),
                    MinTemperature = weather[ i ][ "temp" ][ "min" ].ToString( ),
                    DayTemperature = weather[ i ][ "temp" ][ "day" ].ToString( ),
                    NightTemperature = weather[ i ][ "temp" ][ "night" ].ToString( ),
                    MorningTemperature = weather[ i ][ "temp" ][ "morn" ].ToString( ),
                    EveningTemperature = weather[ i ][ "temp" ][ "eve" ].ToString( ),
                    WindSpeed = weather[ i ][ "speed" ].ToString( ),
                    Cloudy = weather[ i ][ "weather" ][ 0 ][ "description" ].ToString( ),
                    Date = GetDate( weather[ i ][ "dt" ].ToString( ) )
                }
                );

            }

            return Conditions;
        }

        private string GetDate( string time )
        {
            DateTime sdf = new DateTime( 1970, 1, 1, 0, 0, 0, 0 );

            return sdf.AddSeconds( Double.Parse( time ) ).ToLocalTime( ).ToString( ).Split( ' ' )[ 0 ];
        }
    }
}
