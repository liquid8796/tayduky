using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Database
{
    public class DataSource
    {
        string strConnection;
        public DataSource()
        {
            strConnection = getConnectionString();
        }
        public string getConnectionString()
        {
            string strConnection = "server=tayduky123.database.windows.net;database=PRM391;uid=liquid8796;pwd=Qwerty8796";
            return strConnection;
        }
        public string checkLoginAdmin(string email, string password)
        {
            string user = "";
            string SQL = "select * from Admin where email=@Email and password=@Pass";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Pass", password);
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    user = reader.GetValue(2).ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
    }
}
