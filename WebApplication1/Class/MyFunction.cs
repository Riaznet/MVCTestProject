using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class MyFunction
    {

        public static String connection = ConfigurationManager.ConnectionStrings["MyConnection"].ToString();
        private static MyFunction _instance;
        public static MyFunction GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MyFunction();
            }
            return _instance;
        }

        SqlConnection conn;
        SqlCommand cmd;
        public MyFunction()
        {  
            if (conn == null)
                conn = new SqlConnection(connection);
            cmd = new SqlCommand("", conn);
        }

        public DataSet DataSetData(string Script)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Script, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(ds);
                        con.Close();
                        return ds;
                    }
                }
            }
        }
    }
}