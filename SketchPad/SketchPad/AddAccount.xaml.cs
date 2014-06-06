using System;
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
using System.Windows.Shapes;

namespace SketchPad
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public Account Account;

        public AddAccount( )
        {
            InitializeComponent( );
        }

        private void btnOk_Click( object sender, RoutedEventArgs e )
        {
            Account = new Account( );
            Account.Name = txtName.Text;
            Account.SiteName = txtSiteName.Text;
            Account.Login = txtLogin.Text;
            Account.Password = txtPassword.Text;
            Account.Email = txtEmail.Text;

            DoClose( true );
        }

        private void btnCancel_Click( object sender, RoutedEventArgs e )
        {
            DoClose( false );
        }

        private void DoClose( bool result )
        {
            DialogResult = result;
            this.Close( );
        }
    }
}
