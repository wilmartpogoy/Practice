using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace Practice.Connection
{

    
    public class DBConnection

    {
        public static string CONNECTION = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;

        public  SqlConnection _connect = new SqlConnection(CONNECTION);
        public  SqlCommand _command ;
        


        public  bool ConnectionOpen()
        {
            try { 
                if( _connect.State == ConnectionState.Open)
                {
                    _connect.Close();
                }

            _connect.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ConnectioClose()
        {
            try
            {
               

                _connect.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }


}