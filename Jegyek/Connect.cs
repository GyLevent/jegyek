using MySqlConnector;

namespace Jegyek
{
    public class Connect
    {
        public MySqlConnection Connection { get; set; }
        private string Host;
        private string DbName;
        private string UserName;
        private string Password;
        private string ConnectionString;
        public Connect()
        {
            Host = "localhost";
            DbName = "Jegyek";
            UserName = "root";
            Password = "rootpwd";
            ConnectionString = $"server={Host};database={DbName};user={UserName};password={Password}";
            Connection = new MySqlConnection(ConnectionString);
        }
    }
}
