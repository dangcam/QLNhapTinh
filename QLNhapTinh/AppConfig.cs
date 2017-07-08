namespace QLNhapTinh
{
    class AppConfig
    {
        private static string _username;
        private static string _password;
        private static string _role;
        private static string _server;
        private static string _serveroff;
        private static string _database;
        private static string _databaseoff;
        private static string _nhamay;
        
        public static string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public static string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public static string Role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }

        public static string Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
            }
        }

        public static string Database
        {
            get
            {
                return _database;
            }

            set
            {
                _database = value;
            }
        }

        public static string Databaseoff
        {
            get
            {
                return _databaseoff;
            }

            set
            {
                _databaseoff = value;
            }
        }

        public static string Nhamay
        {
            get
            {
                return _nhamay;
            }

            set
            {
                _nhamay = value;
            }
        }

        public static string Serveroff
        {
            get
            {
                return _serveroff;
            }

            set
            {
                _serveroff = value;
            }
        }
    }
}
