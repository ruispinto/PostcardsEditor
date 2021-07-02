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
            string host = "localhost";    		// host name 'localhost', 'web_address', etc...
            string database = "wish_postcards"; // database name
            string port = "3304";               // port used to connect to SQL Server
            string username = "username";  	    // username ('root' - default username if you are using 'localhost')
            string password = "password";     	// password

            // connection string with all the above information in a way SQL connector understands
            string connection_string = "datasource=" + host + ";database=" + database + ";port=" + port + ";username=" + username + ";password=" + password;

            // create a new connection with the given connection string
            connectdb = new MySqlConnection(connection_string);
        }
    }
}
