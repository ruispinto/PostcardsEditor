using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PostcardsEditor.myclass
{
    class connection_class
    {
        // declaration of the variable to connect to the database
        public MySqlConnection connectdb;

        public connection_class()
        {
            // connection to my domain
            string host = "localhost";
            string database = "database_name";
            string port = "port";
            string username = "username";
            string password = "password";

            // connection string with all the above information in a way SQL connector understands
            string connection_string = "datasource=" + host + ";database=" + database + ";port=" + port + ";username=" + username + ";password=" + password;

            // create a new connection with the given connection string
            connectdb = new MySqlConnection(connection_string);
        }
    }
}
