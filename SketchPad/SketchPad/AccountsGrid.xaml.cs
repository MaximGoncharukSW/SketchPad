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
using WeatherControl;

namespace SketchPad
{
    /// <summary>
    /// Interaction logic for AccountsGrid.xaml
    /// </summary>
    public partial class AccountsGrid : UserControl
    {
        private ObservableCollection<Account> accounts;

        public AccountsGrid( )
        {
            InitializeComponent( );

            spWeather.Children.Add( new WeatherGrid( "Макеевка" ) );

            accounts = ( ObservableCollection<Account> )Serializer.Deserialize( Properties.Resources.PathToData );

            if( accounts == null )
                accounts = new ObservableCollection<Account>( );
            else
            {
                foreach( var item in accounts )
                {
                    lstAccount.Items.Add( item.Name );
                }
                lstAccount.SelectedIndex = 0;
            }

            accounts.CollectionChanged +=accounts_CollectionChanged;
        }

        void accounts_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e )
        {
            if( e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add )
                AddToList( e.NewItems[ 0 ] );
            else if( e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove )
                RemoveFromList( e.OldItems[ 0 ] );
        }

        private void RemoveFromList( object p )
        {
            var newAccount = p as Account;

            lstAccount.SelectedIndex = 0;
            lstAccount.Items.Remove( newAccount.Name );
        }

        private void AddToList( object p )
        {
            var newAccount = p as Account;
            lstAccount.Items.Add( newAccount.Name );
        }

        private void btnAdd_Click( object sender, RoutedEventArgs e )
        {
            AddAccount addAccount = new AddAccount( );
            if( addAccount.ShowDialog( ) == true )
                accounts.Add( addAccount.Account );
        }

        public void Close( object sender, System.ComponentModel.CancelEventArgs e )
        {
            Serializer.Serialize( accounts, Properties.Resources.PathToData );
        }

        private void lstAccount_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            ListBox list = sender as ListBox;
            if( list.Items.Count == 0 )
            {
                tbSiteName.Text = "";
                tbLogin.Text = "";
                tbPassword.Text = "";
                tbEmail.Text = "";
                return;
            }

            string selectedName = list.SelectedItem.ToString();

            Account currentAccount = ( from acc in accounts
                                       where acc.Name == selectedName
                                       select acc ).Single( );

            tbSiteName.Text = currentAccount.SiteName;
            tbLogin.Text = currentAccount.Login;
            tbPassword.Text = currentAccount.Password;
            tbEmail.Text = currentAccount.Email;
        }

        private void btnDelete_Click( object sender, RoutedEventArgs e )
        {
            string selctedName = lstAccount.SelectedItem.ToString( );

            var removedAcc = ( from ac in accounts
                               where ac.Name == selctedName
                               select ac ).Single( );
            accounts.Remove( removedAcc );
        }
    }
}
