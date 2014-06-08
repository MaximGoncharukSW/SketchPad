using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Net;

namespace SketchPad
{
    public class Conditions
    {
        public string Cloudy;

        public string MaxTemperature;

        public string MinTemperature;

        public string DayTemperature;

        public string NightTemperature;

        public string WindSpeed;
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

        public void UpdateWeather( )
        {
            if( conditions.Count != 0 )
                conditions.Clear( );

            WebClient client = new WebClient( );
            client.Encoding = Encoding.UTF8;
            string response = client.DownloadString( "http://api.openweathermap.org/data/2.5/forecast/daily?type=json&q=Donetsk&units=metric&cnt=3&lang=ru" );
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
                    WindSpeed = weather[ i ][ "speed" ].ToString( ),
                    Cloudy = weather[ i ][ "weather" ][ 0 ][ "description" ].ToString( )
                }
                );
            }
        }
    }
}
