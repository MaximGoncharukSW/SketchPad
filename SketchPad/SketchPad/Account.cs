using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchPad
{
    [Serializable]
    public class Account
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

        private string siteName;

        public string SiteName
        {
            get
            {
                return siteName;
            }
            set
            {
                siteName = value;
            }
        }
        

        private string login;

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private string email;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}
