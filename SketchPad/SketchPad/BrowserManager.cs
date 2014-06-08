using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace SketchPad
{
    class BrowserManager
    {
        public static void HideScriptErrors( WebBrowser wb, bool hide )
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

        public static void SearchSchedule( WebBrowser wb, string transport, bool? isNow, string toName, string fromName )
        {
            string when = ( isNow == true ) ? "" : "на+всi+днi";
            string url = String.Format( "http://rasp.yandex.ua/search/{0}/?toName={1}&fromName={2}&when={3}", transport, toName, fromName, when );

            wb.Source = new Uri( url );
        }

        public static void SearchWeather( WebBrowser wb )
        {
            string url = String.Format( "http://rp5.ua/Погода_в_Макеевке,_Донецкая_область" );

            wb.Source = new Uri( url );
        }

        internal static void Navigated( object sender, System.Windows.Navigation.NavigationEventArgs e )
        {
            ( ( WebBrowser )sender ).Focus( );
        }
    }
}
